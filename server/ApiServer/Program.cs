using ApiServer.SharedInterfaces;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("/logs/output.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Logger.Information("Server is starting");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services.AddAutoMapper(x =>
    {
        x.IncludeSourceExtensionMethods(typeof(IEntity));
    }, AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectBackEnd.Api", Version = "v1" });

        //var jwtSecurityScheme = new OpenApiSecurityScheme
        //{
        //    Scheme = "bearer",
        //    BearerFormat = "JWT",
        //    Name = "JWT Authentication",
        //    In = ParameterLocation.Header,
        //    Type = SecuritySchemeType.Http,
        //    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        //    Reference = new OpenApiReference
        //    {
        //        Id = JwtBearerDefaults.AuthenticationScheme,
        //        Type = ReferenceType.SecurityScheme
        //    }
        //};
        //c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        //c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //            {
        //                { jwtSecurityScheme, Array.Empty<string>() }
        //            });
    });

    builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    //ilder.Services.AddProjectServicesCollections(builder.Configuration);

    builder.Services.AddDbContext<MainDbContext>(
        dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:SQLLite"],
        b => b.MigrationsAssembly("ApiServer"))
    );// adds the dbcontext with a scoped lifetime

    builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

    builder.Services.AddCors();

    builder.Services.AddMediatR(x => x.AsScoped(), typeof(MediatrAssembly));

    builder.Services.AddCors();

    var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
                .SetIsOriginAllowed(origin => true));// Allow any origin 

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
} 
catch (Exception ex) 
{
    Log.Fatal(ex, "Application failed to start.");
    Console.WriteLine(ex.Message);
} 
finally
{
    Log.CloseAndFlush();
}