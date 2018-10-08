using NTier.Core.Entity;
using NTier.Model.Entities;
using NTier.Model.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Context
{
   public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=MIHALIDIS\\SQLEXPRESS;Database=MihalidisRentACar;Trusted_Connection=true";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BillMap());            
            modelBuilder.Configurations.Add(new CarBrandMap());           
            modelBuilder.Configurations.Add(new CarMap());            
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new RentMap());
            modelBuilder.Configurations.Add(new UserDetailMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bill> Bills { get; set; }        
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }                
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string Identity = WindowsIdentity.GetCurrent().Name;
            string ComputerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            int User = 1;
            string ip = "123";

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item!=null)
                {
                    if (item.State==EntityState.Added)
                    {
                        entity.CreatedUsername = Identity;
                        entity.CreatedComputerName = ComputerName;
                        entity.CreatedDate = dateTime;
                        entity.CreatedBy = User;
                        entity.CreatedIp = ip;

                        entity.Durumu = Core.Entity.Enum.Status.Active;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedUsername = Identity;
                        entity.ModifiedComputerName = ComputerName;
                        entity.ModifiedIp = ip;
                        entity.ModifiedBy = User;
                        entity.ModifiedDate = dateTime;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
