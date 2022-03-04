using Alex.Model;
using System.Web.Http;
using Alex.Model.Dto;
using System.Collections.Generic;

namespace Alex.Application.Controllers
{
    public class TestController : ApiController
    {
        private readonly IService _service;


        public TestController(IService service)
        {
            _service = service;
        }

        public int Get(int id)
        {
            return id;
        }
        public string Get()
        {
            return "alex";
        }
        public string GetMeMore()
        {
            return "alex sin";
        }
        public PersonDto GetPerson(long id)
        {
            return _service.GetPerson(id);
        }
        public List<PersonDto> GetAllPersons()
        {
            //_service.AddPerson(new PersonDto
            //{
            //    Id = 5,
            //    FisrtName = "Joy",
            //    LastName = "Sin",
            //    Age = 6
            //});
            return _service.GetAllPersons();
        }
        [HttpPost]
        public void AddPerson(PersonDto request)
        {
            _service.AddPerson(request);
        }
        [HttpPost]
        public ResponseDto Multiple(RequestDto request)
        {
            return new ResponseDto
            {
                XY = _service.Multiple(request.X, request.Y)
            };
        }
    }
}