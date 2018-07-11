using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Swapi.Api.Client.EndpointHelpers;

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

        public async Task<HttpResponseMessage> Planet(string planetId)
        {
            return await HttpClient.GetAsync(endpointHelper.Planets(planetId));
        }

        public async Task<HttpResponseMessage> GetFilm(string filmId)
        {
            return await HttpClient.GetAsync(endpointHelper.Films(filmId));
        }
    }
}
