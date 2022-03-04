using Alex.Model.Dto;
using Alex.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Alex.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly HttpClient _client;
        public HomeController()
        {
            _client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["endpoint"]) };

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //GetAllPersons();
            //GetPerson(1);
            //AddPerson(new PersonDto
            //{
            //    Id = 6,
            //    FisrtName = "John",
            //    LastName = "Smith",
            //    Age = 50
            //});
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
        public ActionResult GetPerson(long id)
        {
            PersonModel person = new PersonModel();
            HttpResponseMessage res = _client.GetAsync($"/api/test/getperson/{id}").Result;
            using (HttpContent content = res.Content)
            {
                string json = content.ReadAsStringAsync().Result;
                var dto = JsonConvert.DeserializeObject<PersonDto>(json);

                person = new PersonModel
                {
                    Id = dto.Id,
                    FirstName = dto.FisrtName,
                    LastName = dto.LastName,
                    Age = dto.Age
                };
            }
            return View(person);
        }
        //public ActionResult AddPerson(PersonDto dto)
        //{
        //    var content = JsonConvert.SerializeObject(dto);
        //    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        //    var byteContent = new ByteArrayContent(buffer);
        //    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    var res = _client.PostAsync($"/api/test/addperson", byteContent).Result;
           
        //    return View();
        //}
    }
}