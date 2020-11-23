using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClientService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientService.Controllers
{
    public class HotelListController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HotelListController));
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("token not found");

                return RedirectToAction("Login");

            }
            else
            {
                _log4net.Info("Hotels list getting Displayed");

                List<Availablehotels> ItemList = new List<Availablehotels>();
                using (var client = new HttpClient())
                {


                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                    using (var response = await client.GetAsync("https://localhost:44342/api/Availability"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ItemList = JsonConvert.DeserializeObject<List<Availablehotels>>(apiResponse);
                    }
                }
               
                return View(ItemList);
            }
        }
        public async Task<IActionResult> Book(int id)
        {
            _log4net.Info("Booking in progess");
            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }
            else
            {

                Availablehotels Item = new Availablehotels();
                Booking b = new Booking();
                using (var client = new HttpClient())
                {


                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                    using (var response = await client.GetAsync("https://localhost:44342/api/Availability/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Item = JsonConvert.DeserializeObject<Availablehotels>(apiResponse);
                    }
                    b.HotelId = Item.Id;
                    b.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("Userid"));
                    b.StartDate = Convert.ToDateTime(HttpContext.Session.GetString("StartDate"));
                    b.EndDate = Convert.ToDateTime(HttpContext.Session.GetString("EndDate"));
                    b.BillAmount = 0;
                }
                return View(b);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(Booking b)
        {
            _log4net.Info("Booking Done");
            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }
            else
            {

                Availablehotels p = new Availablehotels();

                using (var client = new HttpClient())
                {
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                    using (var response = await client.GetAsync("https://localhost:44342/api/Availability/" + b.HotelId))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        p = JsonConvert.DeserializeObject<Availablehotels>(apiResponse);
                    }

                    int days = (int)( b.EndDate - b.StartDate).TotalDays;
                    b.BillAmount = (double)(days) * (double)p.CostPerDay;
                    b.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("Userid"));




                    StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");

                    using (var response = await client.PostAsync("https://localhost:44364/api/Bookings", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        b = JsonConvert.DeserializeObject<Booking>(apiResponse);
                    }
                    using (var response = await client.PostAsync("https://localhost:44342/api/Availability/" + b.HotelId,content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                    }
                }
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> GetBookingItems(int id)
        {
            _log4net.Info("Getting Booking details");
            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }
            else
            {
                List<Booking> item = new List<Booking>();
                ViewBag.Username = HttpContext.Session.GetString("Username");


                using (var client = new HttpClient())
                {


                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    if (HttpContext.Session.GetInt32("Userid") != null)
                    { id = Convert.ToInt32(HttpContext.Session.GetInt32("Userid")); }

                    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                    using (var response = await client.GetAsync("https://localhost:44364/api/Bookings/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        item = JsonConvert.DeserializeObject<List<Booking>>(apiResponse);
                    }
                }
                return View(item);
            }


        }
    }
}