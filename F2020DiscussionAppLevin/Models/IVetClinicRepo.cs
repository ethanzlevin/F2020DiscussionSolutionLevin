using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public interface IVetClinicRepo
    {
        List<VetClinic> ListAllVetClinics();
    }
}
