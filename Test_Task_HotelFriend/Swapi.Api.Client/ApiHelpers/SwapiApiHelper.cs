using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Swapi.Api.Client.EndpointHelpers;
using Swapi.DataModel.Response;

namespace Swapi.Api.Client.ApiHelpers
{
    public class SwapiApiHelper
    {
        protected HttpClient HttpClient { get; set; }
        private readonly SwapiEndpointHelper endpointHelper;

        public SwapiApiHelper(string url)
        {
            this.HttpClient = new HttpClient { BaseAddress = new Uri(url) };
            this.endpointHelper = new SwapiEndpointHelper();
        }

        public async Task<HttpResponseMessage> GetPeople(string personId)
        {
            return await HttpClient.GetAsync(endpointHelper.People(personId));
        }

        public async Task<HttpResponseMessage> GetPlanet(string planetId)
        {
            return await HttpClient.GetAsync(endpointHelper.Planets(planetId));
        }

        public async Task<HttpResponseMessage> GetFilm(string filmId)
        {
            return await HttpClient.GetAsync(endpointHelper.Films(filmId));
        }

        public async Task<ResponsePersonModel> GetPersonModel(string personId)
        {
            var personResponse = GetPeople(personId).Result;
            if (personResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(
                    $"The 'get person model reques't was finished with status code {personResponse.StatusCode}");
            }

            var personModel = await personResponse.Content.ReadAsAsync<ResponsePersonModel>();

            return personModel;
        }

        public string GetId(string homeworld)
        {
            var regex = new Regex(@"\d{1,2}");

            return regex.Match(homeworld).Value;
        } 

        public async Task<ResponsePlanetModel> GetPlanetModel(string planetId)
        {
            var planetResponse = GetPlanet(planetId).Result;
            if (planetResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(
                    $"The 'get planet model reques't was finished with status code {planetResponse.StatusCode}");
            }

            var planetModel = await planetResponse.Content.ReadAsAsync<ResponsePlanetModel>();

            return planetModel;
        }

        public async Task<ResponseFilmModel> GetFilmModel(string filmId)
        {
            var filmResponse = GetFilm(filmId).Result;
            if (filmResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(
                    $"The 'get film model reques't was finished with status code {filmResponse.StatusCode}");
            }

            var filmModel = await filmResponse.Content.ReadAsAsync<ResponseFilmModel>();

            return filmModel;
        }
    }
}
