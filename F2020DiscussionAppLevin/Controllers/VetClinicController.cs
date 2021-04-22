using F2020DiscussionAppLevin.Models;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace F2020DiscussionAppLevin.Controllers
{
    public class VetClinicController : Controller
    {
        IVetClinicRepo iVetClinicRepo;
        IApplicationUserRepo iApplicationUserRepo;
        IClientRepo iClientRepo;
        public VetClinicController(IVetClinicRepo vetClinicRepo, IApplicationUserRepo applicationUserRepo, IClientRepo clientRepo)
        {
            this.iVetClinicRepo = vetClinicRepo;
            this.iApplicationUserRepo = applicationUserRepo;
            this.iClientRepo = clientRepo;
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

        public List<DistanceViewModel> CreateDistanceMatrix(string origin)
        {

            List<DistanceViewModel> distanceMatrix = new List<DistanceViewModel>();
            //origin = "109 Wilson Ave, Morgantown, WV 26501";

            List<Location> destinationLocations = new List<Location>();

            List<VetClinic> allVetClinics = iVetClinicRepo.ListAllVetClinics();

            foreach (VetClinic eachVetClinic in allVetClinics )
            {
                DistanceViewModel viewModel = new DistanceViewModel();
                viewModel.VetClinicID = eachVetClinic.VetClinicID;
                viewModel.VetClinicAddress = eachVetClinic.VetClinicAddress;
                viewModel.VetClinicName = eachVetClinic.VetClinicName;
                distanceMatrix.Add(viewModel);
                Location location = new Location(eachVetClinic.VetClinicAddress);
                destinationLocations.Add(location);

            }

           DistanceMatrixResponse response = FindDistanceBetweenOriginAndDestinations(origin, destinationLocations);

            Row row = response.Rows.FirstOrDefault();
            List<Element> elements = row.Elements.ToList();

            int distanceInMeters;
            double distanceInMiles;
            const double metersToMileConverter = 0.00062137;
            int durationInSeconds;
            int durationInMinutes;
            int index = 0;

            foreach (Element eachElement in elements)
            {
                distanceInMeters = eachElement.Distance.Value;
                distanceInMiles = Math.Round((distanceInMeters * metersToMileConverter), 2);
                distanceMatrix[index].DistanceInMiles = distanceInMiles;
                durationInSeconds = eachElement.Duration.Value;
                durationInMinutes = durationInSeconds / 60;
                distanceMatrix[index].DurationInMinutes = durationInMinutes;
                index++;
            }

            return distanceMatrix;
        }

        public IActionResult DetermineDistanceMatrix()
        {
            ViewData["Clients"] = new SelectList(iClientRepo.ListAllClients().OrderBy(c => c.Fullname), "Id", "Fullname");
            return View();
        }

        public IActionResult DetermineDistanceMatrixResult(string sortOrder, string clientID)
        {

            //ternary conditional operator
            ViewData["DistanceSortParam"] = String.IsNullOrEmpty(sortOrder) ? "distance_desc" : "";
            ViewData["DurationSortParam"] = sortOrder=="duration" ? "duration_desc" : "duration";

            if(clientID != null)
            {
                HttpContext.Session.SetString("ClientID", clientID);
            }
            else
            {
                clientID = HttpContext.Session.GetString("ClientID");
            }

            Client client = iClientRepo.FindClient(clientID);

            string clientAddress = client.Address;

           List<DistanceViewModel> distanceMatrix = CreateDistanceMatrix(clientAddress);

            switch(sortOrder)
            {
                case "distance_desc": distanceMatrix = distanceMatrix.OrderByDescending(d => d.DistanceInMiles).ToList();  //this whole thing isnt working right now meet with jaren
                    ViewData["DistanceImage"] = "descending";
                    break;
                case "duration":
                    break;
                case "duration_desc":
                break;



                    default: distanceMatrix = distanceMatrix.OrderBy(d => d.DistanceInMiles).ToList();
                    break;
            }

           //distanceMatrix = distanceMatrix.OrderBy(d => d.DistanceInMiles).ToList();

            ViewData["ClientInformation"] = "Client " + client.Fullname + " located at " + client.Address;

            ViewData["Clients"] = new SelectList(iClientRepo.ListAllClients().OrderBy(c => c.Fullname), "Id", "Fullname", clientID);


            return View("DetermineDistanceMatrix", distanceMatrix);
        }


    }

}
