namespace Swapi.DataModel.Response
{
    public class ResponsePlanetsModel
    {
        public string Name { get; set; }
        public string Diameter { get; set; }
        public string Rotation_period { get; set; }
        public string Orbital_period { get; set; }
        public string Gravity { get; set; }
        public string Population { get; set; }
        public string Climate { get; set; }
        public string Terrain { get; set; }
        public string Surface_water { get; set; }
        public string [] Residents { get; set; }
        public string[] Films { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
    }
}
