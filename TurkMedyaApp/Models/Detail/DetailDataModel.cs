namespace TurkMedyaApp.Models.Detail
{
    public class DetailDataModel
    {
        public HeaderAdModel headerAd { get; set; }
        public NewsDetailModel newsDetail { get; set; }
        public FooterAdModel footerAd { get; set; }
        public MultimediaModel multimedia { get; set; }
        public List<DetailItemModel> itemList { get; set; }
        public RelatedNewsModel relatedNews { get; set; }
        public VideoModel video { get; set; }
        public PhotoGalleryModel photoGallery { get; set; }

    }
}
