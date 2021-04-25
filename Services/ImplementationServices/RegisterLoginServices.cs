using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class RegisterLoginServices
    {

        public UserManager<Utilizator> user_manager;
        public SignInManager<Utilizator> _signInManager;

        public RegisterLoginServices (UserManager<Utilizator> user_manager, SignInManager<Utilizator> _signInManager)
        {
            this.user_manager = user_manager;
            this._signInManager = _signInManager;
        }

        public async Task<IdentityResult> Register( Utilizator user, string Password)
        {

            var result = await user_manager.CreateAsync(user, Password);
            return result;
        }

        public async Task<SignInResult> Login(string Email, string Password, bool RememberMe)
        {

            var result = await _signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure: false);
            return result;
        }

    }
}

