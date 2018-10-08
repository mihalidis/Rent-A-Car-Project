using NTier.Model.Entities;
using NTier.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
   public class UserDetailService:BaseService<UserDetail>
    {
        public bool CheckCredentials(string userName, string password)
        {
            return this.Any(x => x.UserName == userName && x.Password == password);
        }
        public UserDetail FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }
    }
}
