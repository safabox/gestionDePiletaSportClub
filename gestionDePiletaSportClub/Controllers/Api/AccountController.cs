using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using gestionDePiletaSportClub.Models.Login;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using gestionDePiletaSportClub.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using gestionDePiletaSportClub.Dtos;
using System.Web;

namespace gestionDePiletaSportClub.Controllers.Api
{
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;
        
        
        
        public AccountController()
        {
            _repo = new AuthRepository();
            
        }

        
        // POST api/Account/Register

        //[AllowAnonymous]
        //[Route("Register")]
        //public async Task<IHttpActionResult> Register(RegisterViewModel userModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await _repo.RegisterUser(userModel);

        //    IHttpActionResult errorResult = GetErrorResult(result);

        //    if (errorResult != null)
        //    {
        //        return errorResult;
        //    }

        //    return Ok();
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("api/login/jwt")]
        public async Task<IHttpActionResult> Authenticate([FromBody] LoginRequest login)
        {
            var loginResponse = new LoginResponse { };
            LoginRequest loginrequest = new LoginRequest { };
            loginrequest.Username = login.Username.ToLower();
            loginrequest.Password = login.Password;

            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage();

            ApplicationUser user = await _repo.FindUser(login.Username,login.Password);

            // if credentials are valid
            if (user != null)
            {
                string token = createToken(user);
                //return the token
                return Ok<string>(token);
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                loginResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(loginResponse.responseMsg);
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Account/Register")]
        public IHttpActionResult RegisterUser(UserDto userDto) {
            ApplicationUser user = null;
            
            try
            {
                user = new ApplicationUser() {
                    Email = userDto.Email,
                    UserName = userDto.Email,
                    PaymentTypeId = userDto.PaymentTypeId,
                    MembershipTypeId = userDto.MembershipTypeId,
                    LevelId = userDto.LevelId,
                    BirthDay = userDto.BirthDay,
                    StartingDate = DateTime.UtcNow.ToString("s"),
                    LastPaymentDate = DateTime.UtcNow.ToString("s"),
                    DueDate = DateTime.UtcNow.AddMonths(1).ToString("s"),
                    AmountOfActivities = userDto.AmountOfActivities,
                    AmountOfPendingActivities = userDto.AmountOfPendingActivities,
                    DNI = userDto.DNI,
                    Name = userDto.Name,
                    LastName = userDto.LastName,
                    PhoneNumber = userDto.PhoneNumber

                };
                var result = _repo.RegisterUsers(user, "Socio");

                if (!result.Succeeded) return BadRequest();


                return Ok();
            }
            catch  {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Account/BlankPassword")]
        public IHttpActionResult BlankPassword()
        {
            
            try
            {
                var result = _repo.BlankPassword("49f7df01-44f3-47e2-af2b-2c2c82d48202", "asdasdasd");

                if (!result.Succeeded) return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        private string createToken(ApplicationUser user)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(1);

            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.SerialNumber,user.Id),
                new Claim(ClaimTypes.DateOfBirth,user.BirthDay == null ? "":user.BirthDay),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim("level",user.LevelId.ToString()),
                new Claim("membership", user.MembershipTypeId.ToString()),
                new Claim("paymentDate",user.LastPaymentDate == null ? "":user.LastPaymentDate),
                new Claim("dueDate",user.DueDate == null ? "":user.DueDate)
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "", audience: "",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        
    }
}
