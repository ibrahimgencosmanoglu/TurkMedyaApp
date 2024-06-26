﻿namespace TurkMedyaApp.Models.HomePage
{
    public class HomePageDataModel
    {
        public string sectionType { get; set; }
        public string repeatType { get; set; }
        public int itemCountInRow { get; set; }
        public bool lazyLoadingEnabled { get; set; }
        public bool titleVisible { get; set; }
        public string title { get; set; }
        public object titleColor { get; set; }
        public string titleBgColor { get; set; }
        public string sectionBgColor { get; set; }
        public List<ItemModel> itemList { get; set; }
        public int totalRecords { get; set; }
    }



}
