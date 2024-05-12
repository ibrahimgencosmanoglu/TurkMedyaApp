using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using TurkMedyaApp.Models.Detail;

namespace TurkMedyaApp.Controllers
{
    public class DetayController : Controller
    {
        //Haber e tiklandiginda acilan sayfa Detay Haber Kismi model olarak index cshtml e gonderiliyor
        public IActionResult Index()
        {
            var json = new WebClient().DownloadString("https://www.turkmedya.com.tr/detay.json");
            var jsonObject = JsonSerializer.Deserialize<DetailDataRootModel>(json);
            var DetailItem = jsonObject.data;
            return View(DetailItem);
        }
    }
}
