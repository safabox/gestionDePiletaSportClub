using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace gestionDePiletaSportClub.Models.Login
{
    public class LoginResponse
    {
        public LoginResponse()
        {

            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }
    }
}