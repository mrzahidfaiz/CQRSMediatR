
using CQRSMediatR.Microservices.StudentApi.Database;
using CQRSMediatR.Microservices.StudentApi.Kafka_Consumer;
using CQRSMediatR.Microservices.StudentApi.Services;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Microservices.StudentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Database
            builder.Services.AddDbContext<StudentApiContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            // Add Services
            builder.Services.AddScoped<IStudentService, StudentService>();
            
            // MediatR
            builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Kafka
            builder.Services.AddHostedService<KafkaConsumer>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
