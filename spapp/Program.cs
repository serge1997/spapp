using spapp.Helpers.Repository.Config;
using spapp.Main.ModelsBuilder.Address;
using spapp.Main.ModelsBuilder.AgentModelBuilder;
using spapp.Main.ModelsBuilder.ComplainModelBuilder;
using spapp.Main.ModelsBuilder.User;
using spapp.Main.Repositories.Address;
using spapp.Main.Repositories.Agent;
using spapp.Main.Repositories.AgentGroup;
using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.Main.Repositories.Complain;
using spapp.Main.Repositories.ComplainType;
using spapp.Main.Repositories.ComplainTypeCategory;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Main.Repositories.NeighborhoodSector;
using spapp.Main.Repositories.Patrol;
using spapp.Main.Repositories.PatrolMember;
using spapp.Main.Repositories.PatrolMunicipality;
using spapp.Main.Repositories.PatrolNeighborhood;
using spapp.Main.Repositories.PatrolNeighborhoodSector;
using spapp.Main.Repositories.User;
using spapp.Main.Repositories.Vehicle;
using spapp.Main.Repositories.VehicleBrand;
using spapp.SpappContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SpappContextDb>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
builder.Services.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();
builder.Services.AddScoped<IAgentRankRepository, AgentRankRepository>();
builder.Services.AddScoped<IAgentGroupRepository,  AgentGroupRepository>();
builder.Services.AddScoped<IAgentRepository,  AgentRepository>();
builder.Services.AddScoped<IComplainTypeCategoryRepository, ComplainTypeCategoryRepository>();
builder.Services.AddScoped<IComplainTypeRepository, ComplainTypeRepository>();
builder.Services.AddScoped<IVehicleBrandRepository, VehicleBrandRepository>();
builder.Services.AddScoped<IVehicleRepository,  VehicleRepository>();
builder.Services.AddScoped<INeighborhoodSectorRepository, NeighborhoodSectorRepository>();
builder.Services.AddScoped<IPatrolRepository, PatrolRepository>();
builder.Services.AddScoped<IAgentModelBuilder, AgentModelBuilder>();
builder.Services.AddScoped<IAddressModelBuilder,  AddressModelBuilder>();
builder.Services.AddScoped<IAddressRepository,  AddressRepository>();
builder.Services.AddScoped<IPatrolMunicipalityRepository, PatrolMunicipalityRepository>();
builder.Services.AddScoped<IPatrolNeighborhoodRepository,  PatrolNeighborhoodRepository>();
builder.Services.AddScoped<IPatrolNeighborhoodSectorRepository,  PatrolNeighborhoodSectorRepository>();
builder.Services.AddScoped<IPatrolMemberRepository,  PatrolMemberRepository>();
builder.Services.AddScoped<IUserRepository,  UserRepository>();
builder.Services.AddScoped<IComplainRepository, ComplainRepository>();
builder.Services.AddSingleton<IConfigService,  ConfigService>();

//builder
builder.Services.AddScoped<IUserModelBuilder, UserModelBuilder>();
builder.Services.AddScoped<IComplainModelBuilder, ComplainModelBuilder>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
});
var app = builder.Build();

app.UseCors("AllowAllOrigins");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();
app.Run();
