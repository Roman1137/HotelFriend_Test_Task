using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swapi.DataModel.Response;

namespace Swapi.Api.Tests.ApiTests
{
    public class DataProvider
    {
        public static IEnumerable<ExpectedModel> ExpectedValues
        {
            get
            {
                yield return new ExpectedModel
                {
                    personModel = new ResponsePersonModel
                    {
                        Name = "Luke Skywalker"
                    },

                    planetModel = new ResponsePlanetModel
                    {
                        Name = "Tatooine",
                        Population = "200000"
                    },

                    filmModel = new ResponseFilmModel
                    {
                        Title = "Attack of the Clones"
                    }
                };
            }
        }

    }
}
