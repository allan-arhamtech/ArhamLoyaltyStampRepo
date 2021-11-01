using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.Common
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
            };
        }

        public static class UserManagement
        {
            public const string View = "Permissions.UserManagement.View";
            public const string Create = "Permissions.UserManagement.Create";
            public const string Edit = "Permissions.UserManagement.Edit";
            public const string Delete = "Permissions.UserManagement.Delete";
        }

        public static class Company
        {
            public const string View = "Permissions.Company.View";
            public const string Create = "Permissions.Company.Create";
            public const string Edit = "Permissions.Company.Edit";
            public const string Delete = "Permissions.Company.Delete";
        }
    }
}
