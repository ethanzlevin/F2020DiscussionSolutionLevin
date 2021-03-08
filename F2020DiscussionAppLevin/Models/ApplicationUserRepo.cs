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

        public string FindUserID()
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            string userID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userID;
        }//end FindUserID

    }
}
