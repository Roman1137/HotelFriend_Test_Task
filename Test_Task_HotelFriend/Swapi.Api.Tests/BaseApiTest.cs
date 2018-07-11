using NUnit.Framework;
using Swapi.Api.Client.ApiHelpers;
using Swapi.Api.Client.EndpointHelpers;

namespace Swapi.Api.Tests
{
    public class BaseApiTest
    {
        protected SwapiApiHelper SwapiApiHelper;
        protected SwapiEndpointHelper SwapiEndpointHelper;
        public string serviceUrl;

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            serviceUrl = "https://swapi.co/";

            if (this.SwapiApiHelper == null && this.SwapiEndpointHelper == null)
            {
                this.SwapiApiHelper = new SwapiApiHelper(this.serviceUrl);
                this.SwapiEndpointHelper = new SwapiEndpointHelper();
            }
        }
    }
}
