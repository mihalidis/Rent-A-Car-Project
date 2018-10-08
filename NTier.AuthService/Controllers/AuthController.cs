using NTier.AuthService.Models;
using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NTier.AuthService.Controllers
{
    public class AuthController : ApiController
    {
        UserDetailService _userDetailService;
        public AuthController()
        {
            _userDetailService = new UserDetailService();
        }
        [HttpPost]
        public HttpResponseMessage Login(Credentials model)
        {
            var url = "";
            if (model.Username==null||model.Password==null)
            {
                url = "http://localhost:58112/Main/Login";
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
            }
            if (_userDetailService.CheckCredentials(model.Username,model.Password))
            {
                UserDetail kullanici = new UserDetail();
                kullanici = _userDetailService.FindByUserName(model.Username);
                if (kullanici.Role==Role.Admin)
                {
                    url = "http://localhost:58112/Admin/Home/Index/" + kullanici.Id;
                    return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = url });
                }
                else if (kullanici.Role==Role.Member)
                {
                    url = "http://localhost:58112/Main/HomePage/" + kullanici.Id;
                    return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = url });
                }
                else
                {
                    url = "http://localhost:58112/Main/HomePage";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = url });
                }
            }
            url = "http://localhost:58112/Main/Login";
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
        }
    }
}
