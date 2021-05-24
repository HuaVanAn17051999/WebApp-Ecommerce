using DO_AN_SEM3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DO_AN_SEM3.Models.Common
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var db = new anhvDbContext())
            {
                var role = db.UserRoles
                    .Where(x => x.User.TenDangNhap == username)
                    .Select(a => a.Role.Name)
                    .ToArray();
                return role;



                   
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            //using (var userContext = new anhvDbContext())
            //{
            //    var user = userContext.Users.SingleOrDefault(u => u.UserName == username);
            //    var userRoles = userContext.Roles.Select(r => r.Name);

            //    if (user == null)
            //        return new string[] { };
            //    return user.Roles == null ? new string[] { } :
            //        userRoles.ToArray();
            //}
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}