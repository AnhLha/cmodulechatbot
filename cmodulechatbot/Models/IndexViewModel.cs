namespace cmodulechatbot.Models
{
    public class IndexViewModel
    {
        public IEnumerable<WeatherModel> ListWeather;
        public IEnumerable<ServiceModel> ListService;

        public IndexViewModel()
        {
        
        }

        public IndexViewModel(IEnumerable<WeatherModel> _ListWeather, IEnumerable<ServiceModel> _ListService)
        {
            ListWeather = _ListWeather;
            ListService = _ListService;
        }

        public void setListService(IEnumerable<ServiceModel> _ListService)
        {
            ListService = _ListService;
        }

        public void setListWeather(IEnumerable<WeatherModel> _ListWeather)
        {
            ListWeather = _ListWeather;

        }
    }
}
