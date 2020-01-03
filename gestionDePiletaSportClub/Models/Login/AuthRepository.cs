using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestionDePiletaSportClub.DAL;
using gestionDePiletaSportClub.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace gestionDePiletaSportClub.Models.Login
{
    
    public class AuthRepository : IDisposable
    {
        private ApplicationDBContext _ctx;

        private UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _ctx = new ApplicationDBContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(RegisterViewModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public IdentityResult RegisterUsers(ApplicationUser userModel, string rol)
        {

        //var result = await _userManager.CreateAsync(userModel, "sportclub");
            var result= _userManager.Create<ApplicationUser, string>(userModel, "sportclub");
            if (result.Succeeded) {
                //await _userManager.AddToRoleAsync(userModel.Id, "Socio");
                result= _userManager.AddToRole<ApplicationUser, string>(userModel.Id, rol);

            }

            return result;
        }
        public async Task<ApplicationUser> FindUser(string userName, string password)
            {
                ApplicationUser user = await _userManager.FindAsync(userName, password);

                return user;
            }
        public ApplicationUser FindUserSync(LoginRequest loginRequest)
        {
            ApplicationUser user = _userManager.Find(loginRequest.Username, loginRequest.Password);

            return user;
        }

        public void Dispose()
            {
                _ctx.Dispose();
                _userManager.Dispose();

            }
        }
    
}