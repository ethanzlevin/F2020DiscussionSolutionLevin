using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace F2020DiscussionAppLevin.Controllers
{
    public class AddressController : Controller
    {
        public string GetAddressDataInJson(string term) //JQuery method autocomplete - string must be called term
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "AIzaSyBBaIWfDUtMsIiyDduh0hHQ0T6oYCO3flc",
                Input = term,
                Types = new List<RestrictPlaceType> { RestrictPlaceType.Address},
                Location = new GoogleApi.Entities.Common.Location("Morgantown, WV"),
                Radius = 50
            };

            var response = GoogleApi.GooglePlaces.AutoComplete.Query(request);

            var result = response.Predictions.ToArray();

            return JsonConvert.SerializeObject(result);



        }

        public IActionResult GetAddressInformation()
        {
            return View();
        }

        public IActionResult GetAddressInformationResult(string selectedAddress)
        {
            return View("GetAddressInformation", selectedAddress);
        }
    }
}
