using GenericEFpoc.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GenericEFpoc.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IContextService _service;
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(IContextService service, ILogger<ExampleController> logger)
        {
            this._service = service;
            _logger = logger;
        }
        [HttpGet("test")]
        public IActionResult GetExperimental(string table, int id)
        {

            Type entityType = Type.GetType($"GenericEFpoc.Model.{table}");
            return new ContentResult() { ContentType = "application/json", StatusCode = 200, Content = JsonSerializer.Serialize(_service.Get<entityType>(id)) };

            switch (table)
            {
                case "Student":
                    return new ContentResult() { ContentType = "application/json", StatusCode = 200, Content = JsonSerializer.Serialize(_service.Get<Student>(id)) };
                case "Teacher":
                    return new ContentResult() { ContentType = "application/json", StatusCode = 200, Content = JsonSerializer.Serialize(_service.Get<Teacher>(id)) };

            }

        }


        //[HttpGet]
        //public IActionResult Get(string table, int id) => new ContentResult() { ContentType = "application/json", StatusCode = 200, Content = JsonSerializer.Serialize(_service.Get(table, id)) };
        [HttpPost]
        public IActionResult Post([FromBody] object someEntity) => _service.Add(someEntity) == true ? new OkResult() : BadRequest();
        [HttpPut]
        public IActionResult Put([FromBody] object someEntity) => _service.Update(someEntity) == true ? new OkResult() : BadRequest();
        [HttpDelete]
        public IActionResult Delete([FromBody] object someEntity) => _service.Delete(someEntity) == true ? new OkResult() : BadRequest();
        [HttpDelete("wow")]
        public IActionResult Blubb([FromBody] Student test) => _service.Delete(test) == true ? new OkResult() : BadRequest();

    }
}