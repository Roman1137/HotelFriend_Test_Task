using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Api.Client.EndpointHelpers
{
    public class SwapiEndpointHelper
    {
        public string People(string personId) => $"api/people/{personId}/";

        public string Planets(string planetId) => $"api/planets/{planetId}/";

        public string Films(string filmId) => $"api/films/{filmId}/";
    }
}
