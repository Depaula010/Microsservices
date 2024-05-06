using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddStackExchangeRedisCache(options =>
{
    // Criar e configurar as opções de configuração
    var configurationOptions = new ConfigurationOptions
    {
        EndPoints = { "basketdb:6379" }, // Endereço e porta do servidor Redis
        ConnectTimeout = 5000 // Tempo limite de conexão em milissegundos
    };

    options.ConfigurationOptions = configurationOptions;
    options.InstanceName = "Interactive"; // Nome da instância, se aplicável
});

builder.Services.AddScoped<IBasketRepository, BasketRepositories>();
builder.Services.AddScoped<DiscountGrpcService>();
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
    o => o.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
