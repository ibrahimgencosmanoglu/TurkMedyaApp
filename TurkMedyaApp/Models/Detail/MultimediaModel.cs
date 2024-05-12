namespace TurkMedyaApp.Models.Detail
{
    public class MultimediaModel
    {
        public string sectionType { get; set; }
        public string repeatType { get; set; }
        public int itemCountInRow { get; set; }
        public bool lazyLoadingEnabled { get; set; }
        public bool titleVisible { get; set; }
        public object title { get; set; }
        public object titleColor { get; set; }
        public object titleBgColor { get; set; }
        public object sectionBgColor { get; set; }
    }
}
