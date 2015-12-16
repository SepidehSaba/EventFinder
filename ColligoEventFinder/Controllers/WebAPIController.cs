using System;
using System.Net;
using System.Web.Http;
using ColligoEventFinder.Models;
using System.Runtime.Serialization.Json;
using System.IO;
namespace ColligoEventFinder.Controllers
{
    public class WebAPIController : ApiController
    {
        // The application key registered by Eventful: zzKnVJcGtc7rGt96
        private const string EventfullUrl = "http://api.eventful.com/json/events/search?app_key=zzKnVJcGtc7rGt96";
        private const string GoogleUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=";

        // To validate the address via google
        [HttpGet]
        [ActionName("ValidateAddress")]
        public IHttpActionResult ValidateAddress(string address)
        {
            dynamic googleResults = this.CallGoogle(address);
            double[] coordinates = WebHelper.ValidateAddressLookup(googleResults);

            if (coordinates != null)
            {
                return Ok(coordinates);
            }
            return Ok();
        }

        public dynamic CallGoogle(string address)
        {
            return new Uri(GoogleUrl + address).GetDynamicJsonObject();
        }

        // To submit the query to Eventful
        [HttpGet]
        [ActionName("GetEvent")]
        public IHttpActionResult GetEvent([FromUri] EventQuery queryData)
        {
            SearchResult eventList;

            String queryString = buildQueryString(queryData);
            queryString = EventfullUrl + queryString;

            WebRequest request = (HttpWebRequest)WebRequest.Create(queryString);

            using (WebResponse response = request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                Type t = typeof(SearchResult);

                // Parse and loads the Json response into Data Contracts
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SearchResult));
                eventList = (SearchResult)ser.ReadObject(dataStream);
                response.Close();
            }

            return Ok(eventList);
        }

        // Builds the search query string from the search form inpouts
        private string buildQueryString(EventQuery queryData)
        {
            String queryString = "&where=" + queryData.coordinates;
            queryString += "&keywords=" + queryData.keywords;
            queryString += "&date=" + queryData.dates;
            if (queryData.radius > 0)
            {
                queryString += "&within=" + queryData.radius;
            }
            queryString += "&units=km";
            queryString += "&page_number=" + queryData.pageNumber;

            return queryString;
        }
    }
}