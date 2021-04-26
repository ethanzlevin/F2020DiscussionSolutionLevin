using F2020DiscussionAppLevin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class VetClinicRepo : IVetClinicRepo
    {
        private ApplicationDbContext database;
        public VetClinicRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }
        public List<VetClinic> ListAllVetClinics()
        {
            List<VetClinic> vetClinics = database.VetClinic.ToList();
            return vetClinics;

        }

    }
}
