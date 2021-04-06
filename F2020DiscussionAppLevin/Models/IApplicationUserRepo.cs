using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public interface IApplicationUserRepo
    {
        string FindUserID();
        List<ApplicationUser> ListAllAppUsers();
        string GetCurrentRoles(string id);
        string GetAvailableRoles(string id);
    }
}
