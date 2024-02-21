using BusinessLayer.AccountBL;
using BusinessLayer.BrandBL;
using BusinessLayer.CategoryBL;
using BusinessLayer.OrderBL;
using BusinessLayer.OrderDetailBL;
using BusinessLayer.ProductBL;
using DataAccessLayer;
using DataAccessLayer.AccountDL;
using DataAccessLayer.BrandDL;
using DataAccessLayer.CategoryDL;
using DataAccessLayer.OrderDetailDL;
using DataAccessLayer.OrderDL;
using DataAccessLayer.ProductDL;
using BusinessLayer.BaseStoreBL;
using DataAccessLayer.BaseStoreDL;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddScoped(typeof(IBaseStoreDL<>), typeof(BaseStoreDL<>));
builder.Services.AddScoped(typeof(IBaseStoreBL<>), typeof(BaseStoreBL<>));

builder.Services.AddScoped<IAccountDL, AccountDL>();
builder.Services.AddScoped<IAccountBL, AccountBL>();

builder.Services.AddScoped<IOrderDL, OrderDL>();
builder.Services.AddScoped<IOrderBL, OrderBL>();

builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<IProductBL, ProductBL>();

builder.Services.AddScoped<ICategoryDL, CategoryDL>();
builder.Services.AddScoped<ICategoryBL, CategoryBL>();

builder.Services.AddScoped<IOrderDetailDL, OrderDetailDL>();
builder.Services.AddScoped<IOrderDetailBL, OrderDetailBL>();

builder.Services.AddScoped<IBrandDL, BrandDL>();
builder.Services.AddScoped<IBrandBL, BrandBL>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCors(option =>
{
    option.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
});
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
