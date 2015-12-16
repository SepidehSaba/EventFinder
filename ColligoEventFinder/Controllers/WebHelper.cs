using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColligoEventFinder.Controllers
{
    // Created for improving testablity
    public class WebHelper
    {
        // parse the result from a google API call and return the coordiantes
        public static double[] ValidateAddressLookup(dynamic googleResults)
        {
            if (googleResults.status.Contains("OK"))
            {
                double lan = googleResults.results[0].geometry.location.lat;
                double lng = googleResults.results[0].geometry.location.lng;
                return new double[] { lan, lng };
            }
            else
            {
                return null;
            }
        }
    }
}