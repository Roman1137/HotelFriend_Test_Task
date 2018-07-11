using System.Linq;
using NUnit.Framework;
using Swapi.DataModel.Response;
using FluentAssert;

namespace Swapi.Api.Tests.ApiTests
{
    [TestFixture]
    public class SwapiApiTests : BaseApiTest
    {
        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.ExpectedValues))]
        public void VerifyPeopleFilmsPlanets(ExpectedModel expectedModel)
        {
            const string personId = "1";

            var actualPersonModel = SwapiApiHelper.GetPersonModel(personId).Result;
            actualPersonModel.Name.ShouldBeEqualTo(expectedModel.personModel.Name);

            var planetId = SwapiApiHelper.GetId(actualPersonModel.Homeworld);
            var actualPlanetModel = SwapiApiHelper.GetPlanetModel(planetId).Result;

            actualPlanetModel.Name.ShouldBeEqualTo(expectedModel.planetModel.Name);
            actualPlanetModel.Population.ShouldBeEqualTo(expectedModel.planetModel.Population);

            var firstFilmId = SwapiApiHelper.GetId(actualPlanetModel.Films.First());
            var actualFilmModel = SwapiApiHelper.GetFilmModel(firstFilmId).Result;

            actualFilmModel.Title.ShouldBeEqualTo(expectedModel.filmModel.Title);
            actualFilmModel.Planets.Contains(actualPlanetModel.Url).ShouldBeTrue(
                $"Film model should have contained planet {actualPlanetModel.Name} with Url {actualPlanetModel.Url}");
            actualFilmModel.Characters.Contains(actualPersonModel.Url).ShouldBeTrue(
                $"Film model should have contained person {actualPersonModel.Name} with Url {actualPersonModel.Url}");
        }
    }
}
