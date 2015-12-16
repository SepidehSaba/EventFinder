using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using ColligoEventFinder.Controllers.Fakes;
using System.Web.Http;

namespace ColligoEventFinder.Controllers.Tests
{
    [TestClass()]
    public class WebHelperTests
    {
        [TestMethod()]
        public void ValidateAddressLookupTest()
        {
            using (ShimsContext.Create())
            {
                new Fakes.ShimWebAPIController()
                {
                    CallGoogleString = (address) => { return null; }
                };
                
                WebAPIController objectUnderTest = new WebAPIController();
                IHttpActionResult result = objectUnderTest.ValidateAddress("Invalid address");
            }
        }
    }
}