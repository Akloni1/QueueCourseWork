using Consumer.Interfaces;
using Consumer.Kafka;
using Consumer.RabbitMQ;
using Consumer.Services.RabbitMQ;
using Prometheus;

namespace Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IBankAccountService, BankAccountService>();
            builder.Services.AddHostedService<RabbitMqListener>();
            builder.Services.AddHostedService<KafkaListener>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMetricServer();

            app.MapControllers();

            app.Run();
        }
    }
}