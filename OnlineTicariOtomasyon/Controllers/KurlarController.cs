using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KurlarController : Controller
    {
        // GET: Kurlar
        string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
        WebClient webClient = new WebClient();
    
        public ActionResult Index()
        {

            ViewBag.result = GetLastUpdatedTime().ToString("dd.MM.yyyy HH:mm:ss");

            
            return View(GetCurrencies());
     
        }

        public List<Currency> GetCurrencies()
        {
            
                string xmlData = webClient.DownloadString(url);
            XDocument doc = XDocument.Parse(xmlData);
            List<Currency> currencies = new List<Currency>();

         
            var usdNode = doc.Descendants("Currency")
                             .Where(c => c.Attribute("Kod").Value == "USD").FirstOrDefault();

            if (usdNode != null)
            {
                var usd = new Currency
                {
                    Code = usdNode.Attribute("Kod").Value,
                    Name = usdNode.Element("Isim").Value,
                    ForexBuying = decimal.Parse(usdNode.Element("ForexBuying").Value.Replace(".", ",")),
                    ForexSelling = decimal.Parse(usdNode.Element("ForexSelling").Value.Replace(".", ","))
                };

                currencies.Add(usd);
            }

         
            var euroNode = doc.Descendants("Currency")
                              .Where(c => c.Attribute("Kod").Value == "EUR").FirstOrDefault();

            if (euroNode != null)
            {
                var euro = new Currency
                {
                    Code = euroNode.Attribute("Kod").Value,
                    Name = euroNode.Element("Isim").Value,
                    ForexBuying = decimal.Parse(euroNode.Element("ForexBuying").Value.Replace(".", ",")),
                    ForexSelling = decimal.Parse(euroNode.Element("ForexSelling").Value.Replace(".", ","))
                };

                currencies.Add(euro);
            }

            return currencies;
        }


        public  DateTime GetLastUpdatedTime()
        {
            var _xmlData = webClient.DownloadString(url);
            var doc = XDocument.Parse(_xmlData);
            var tarihString = doc.Descendants("Tarih_Date").FirstOrDefault().Attribute("Tarih").Value;
            var tarih = DateTime.ParseExact(tarihString, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

            var lastUpdateTime = new DateTime(tarih.Year, tarih.Month, tarih.Day, 15, 30, 0);
            if (DateTime.Now < lastUpdateTime)
            {
                lastUpdateTime = lastUpdateTime.AddDays(-1);
            }

            return lastUpdateTime;
        }
    }
}