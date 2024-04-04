using CQRSMediatR.ApiGateway.Api.Kafka_Service;
using CQRSMediatR.ApiGateway.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CQRSMediatR.ApiGateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly KafkaService _kafkaService;

        public StudentController(KafkaService kafkaService)
        {
            _kafkaService = kafkaService;
        }

        [HttpPost]
        public async Task<Student> AddStudent([FromBody] Student student)
        {
           var payload = JsonSerializer.Serialize<Student>(student);

            await _kafkaService.AddStudent("AddStudent", payload);

            return student;
        }
    }
}
