using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;

using gRPCData.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<IAlienLogic, AlienLogic>();
builder.Services.AddScoped<ICustomerDao, CustomerDao>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();
builder.Services.AddScoped<IFarmerDao, FarmerDao>();
builder.Services.AddScoped<IFarmerLogic, FarmerLogic>();
builder.Services.AddScoped<IOrderDao, OrderDao>();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();
builder.Services.AddScoped<IOrderItemDao, OrderItemDao>();
builder.Services.AddScoped<IOrderItemLogic, OrderItemLogic>();
builder.Services.AddScoped<IProductDao, ProductDao>();
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IReceiptDao, ReceiptDao>();
builder.Services.AddScoped<IReceiptLogic, ReceiptLogic>();
builder.Services.AddScoped<IReviewDao, ReviewDao>();
builder.Services.AddScoped<IReviewLogic, ReviewLogic>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();