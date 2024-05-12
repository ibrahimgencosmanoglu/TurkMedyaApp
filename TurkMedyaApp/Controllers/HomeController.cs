using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using TurkMedyaApp.Models;
using TurkMedyaApp.Models.HomePage;

namespace TurkMedyaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<ItemModel> NewsSectionDatas { get; set; }
        public List<ItemModel> Items { get; set; }
        public int CurrentPageIndex { get; set; }
        public int TotalPages { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //JSON datayi Verilen Parametrelerle URLden cagiriyor
        private void GetItems(string categoryId, string filterText)
        {
            var json = new WebClient().DownloadString("https://www.turkmedya.com.tr/anasayfa.json");
            var jsonObject = JsonSerializer.Deserialize<HomePageDataRootModel>(json);
            var tempItems = jsonObject.data.Where(x => x.sectionType == "SWIPE").FirstOrDefault().itemList.ToList();
            tempItems.AddRange(jsonObject.data.Where(x => x.sectionType == "NEWS").FirstOrDefault().itemList);
            Items = tempItems.Where(x => x.category.categoryId.ToLower().Contains(categoryId) && x.title.ToLower().Contains(filterText.ToLower())).ToList();
            var Categories = tempItems.Where(x => !x.category.slug.Contains("\"") || !x.category.slug.Contains("")).Select(x => x.category).DistinctBy(x => x.categoryId).ToList();
            Categories.Add(new CategoryModel
            {
                categoryId = "",
                slug = "hepsi",
                title = "TÜM KATEGORİLER",
            });
            ViewBag.DropdownCategories = Categories.OrderBy(x=>x.categoryId); // Kategoriler Bilinmedigi icin JSON Verisinden Cekip DropDown List Olusturdum
        }
        public IActionResult Index(int page = 1, int pageSize = 5, string categoryId = "",string filterText = "")
        {
            ViewBag.categoryId = categoryId;
            ViewBag.filterText = filterText;
            GetItems(categoryId, filterText);
            ViewBag.TotalPages = Items.Count / 5;
            var items = Items
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            ViewBag.PageNumber = page;
            return View(items); // Items Model olarak Index Cshtml e gonderiliyor.
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
