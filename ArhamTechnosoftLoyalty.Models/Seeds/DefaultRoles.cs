using ArhamTechnosoftLoyalty.Models.EntityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("SuperAdmin".ToString()));
            await roleManager.CreateAsync(new IdentityRole("CompanyAdmin".ToString()));
            await roleManager.CreateAsync(new IdentityRole("Customer".ToString()));
        }
    }
}
