using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public interface IPetRepo
    {
        //list of method signatures
        //what should be done but not how (not implemented)
        List<Pet> ListAllPets();

        List <Client> ListAllClients();

    }


}
