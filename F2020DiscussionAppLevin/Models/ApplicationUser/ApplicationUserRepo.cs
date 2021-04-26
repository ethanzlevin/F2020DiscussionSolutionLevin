using F2020DiscussionAppLevin.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {
        private ApplicationDbContext database;

       

        // dependancy injection
        public ApplicationUserRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
            
        }

        public ApplicationUser FindApplicationUser(string id)
        {
           ApplicationUser user = database.ApplicationUser.Find(id);
            return user;
        }

        public string FindUserID()
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            string userID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userID;
        }//end FindUserID

        public string GetAvailableRoles(string id)
        {
            string jsonData = null;

            var availableRoleList =

                from R in database.Roles
                where !
                (
                from UR in database.UserRoles
                where UR.UserId == id
                select UR.RoleId
                )
                .Contains(R.Id)
                select new { R.Id, R.Name };

            jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(availableRoleList);


            return jsonData;
        }

        public string GetCurrentRoles(string id)
        {
            string jsonData = null;

            var userRoleList =
                from UR in database.UserRoles
                join R in database.Roles
                on UR.RoleId equals R.Id
                where UR.UserId == id
                select new { R.Id, R.Name };

            jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(userRoleList);

            return jsonData;
        }

        public List<ApplicationUser> ListAllAppUsers()
        {
            List<ApplicationUser> applicationUsers = database.ApplicationUser.ToList();
            return applicationUsers;
        }
    }
}
