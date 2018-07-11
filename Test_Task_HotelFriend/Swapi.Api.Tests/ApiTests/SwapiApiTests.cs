using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Swapi.Api.Client;
using Swapi.DataModel.Response;

namespace Swapi.Api.Tests.ApiTests
{
    [TestFixture]
    public class SwapiApiTests : BaseApiTest
    {
        [Test]
        [TestCase("1")]
        public async Task VerifyPeopleFilmsPlanets(string personId)
        {
            var personResponse = SwapiApiHelper.GetPeople(personId).Result.Content;
            var personModel = await personResponse.ReadAsAsync<ResponsePeopleModel>();

        }
    }
}
