namespace TurkMedyaApp.Models.HomePage
{
    public class HomePageDataRootModel
    {
        public int errorCode { get; set; }
        public object errorMessage { get; set; }
        public List<HomePageDataModel> data { get; set; }
    }
}
