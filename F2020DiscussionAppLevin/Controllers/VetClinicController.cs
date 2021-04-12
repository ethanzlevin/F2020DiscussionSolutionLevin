using F2020DiscussionAppLevin.Models;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace F2020DiscussionAppLevin.Controllers
{
    public class VetClinicController : Controller
    {
        IVetClinicRepo iVetClinicRepo;
        public VetClinicController(IVetClinicRepo vetClinicRepo)
        {
            this.iVetClinicRepo = vetClinicRepo;
        }

        public DistanceMatrixResponse FindDistanceBetweenOriginAndDestinations(string origin, List<Location> destinationLocation)
        {
            DistanceMatrixResponse response = new DistanceMatrixResponse();

            Location originloc = new Location(origin);
            List<Location> originLocations = new List<Location>();
            originLocations.Add(originloc);

            

            DistanceMatrixRequest request = new DistanceMatrixRequest();
            request.Key = "AIzaSyBBaIWfDUtMsIiyDduh0hHQ0T6oYCO3flc";
            request.Destinations = destinationLocation;
            request.Origins = originLocations;

            response = GoogleApi.GoogleMaps.DistanceMatrix.Query(request);
            

            return response;
        }

        public DistanceMatrixResponse CreateDistanceMatrix(string origin)
        {
            origin = "109 Wilson Ave, Morgantown, WV 26501";

            List<Location> destinationLocations = new List<Location>();

            List<VetClinic> allVetClinics = iVetClinicRepo.ListAllVetClinics();

            foreach (VetClinic eachVetClinic in allVetClinics )
            {
                Location location = new Location(eachVetClinic.VetClinicAddress);
                destinationLocations.Add(location);
            }

           DistanceMatrixResponse response = FindDistanceBetweenOriginAndDestinations(origin, destinationLocations);

            return response;
        }


    }

}
