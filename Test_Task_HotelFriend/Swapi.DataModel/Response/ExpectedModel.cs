using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.DataModel.Response
{
    public class ExpectedModel
    {
        public ResponsePersonModel personModel { get; set; }
        public ResponsePlanetModel planetModel { get; set; }
        public ResponseFilmModel filmModel { get; set; }
    }
}
