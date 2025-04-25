namespace test2.Model.CitiesActions
{
    public class UpdateCities
    {
        public string name { get; set; }
        public string descreption { get; set; }
        public int rating { get; set; }
        public string image { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int AveragePerNight { get; internal set; }
    }
}