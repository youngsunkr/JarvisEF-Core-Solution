using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JarvisEF.Core.Security;
using JarvisEF.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace JarvisEF.WebAPI.Controllers
{
    public class LoginController : ControllerBase
    {
        public GlobalValues _GlobalValues { get; }

        public Auth_Token Login([FromBody]Login dataModel)
        {
            string strAES256Enc = AES.AES_encrypt(dataModel.strUserID
                + "|" + dataModel.strUserPW
                + "|" + DateTime.Now.AddHours(1).ToString()
                , _GlobalValues.EncryptKey);

            var result = new Auth_Token();
            result.strHeader = "ReToken";
            result.strToken = strAES256Enc;

            return result;
        }
    }
}