using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Alex.Model.Dto;
using Alex.MVC.Models;
using Newtonsoft.Json;

namespace Alex.MVC.Controllers
{
    public class PersonController : Controller
    {
        readonly HttpClient _client;
        public PersonController()
        {
            
            _client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["endpoint"]) };

        }
        // GET: Person
        public ActionResult Index()
        {
            ViewBag.Persons = getAllPersons();
            return View("Person");
        }
        [HttpPost]
        public ActionResult AddPerson(string FirstName, string LastName, int Age)
        {

            addPerson(new PersonDto
            {
                FisrtName = FirstName,
                LastName = LastName,
                Age = Age
            });
            ViewBag.Persons = getAllPersons();
            return View("Person");
        }
        [HttpPost]
        public ActionResult UpdatePerson()
        {
            //var firstname = formCollection.GetValue("firstname").ToString();
            //var lastname = formCollection.GetValue("lastname").ToString();
            //var age = 111;// formCollection.GetValue("age").ToString();
            //addPerson(new PersonDto
            //{
            //    FisrtName = firstname,
            //    LastName = lastname,
            //    Age = age
            //});
            return View("Person");
        }
        private List<PersonModel> getAllPersons()
        {
            List<PersonModel> persons = new List<PersonModel>();
            HttpResponseMessage res = _client.GetAsync("/api/test/getallpersons").Result;
            using (HttpContent content = res.Content)
            {
                string json = content.ReadAsStringAsync().Result;
                var dtos = JsonConvert.DeserializeObject<List<PersonDto>>(json);

                foreach (var dto in dtos)
                {
                    persons.Add(new PersonModel
                    {
                        Id = dto.Id,
                        FirstName = dto.FisrtName,
                        LastName = dto.LastName,
                        Age = dto.Age
                    });
                }
            }
            return persons;
        }

        private void addPerson(PersonDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var res = _client.PostAsync($"/api/test/addperson", byteContent).Result;
        }
    }
}