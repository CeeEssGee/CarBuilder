using System.Net.NetworkInformation;
using CarBuilderAPI.Models;

List<PaintColor> paintColors = new List<PaintColor>
{
    new PaintColor()
    {
        Id = 1,
        Price = 350M,
        Color = "Silver"
    },
    new PaintColor()
    {
        Id = 2,
        Price = 400M,
        Color = "Midnight Blue"
    },
    new PaintColor()
    {
        Id = 3,
        Price = 450M,
        Color = "Firebrick Red"
    },
    new PaintColor()
    {
        Id = 4,
        Price = 500M,
        Color = "Spring Green"
    }
};

List<Interior> interiors = new List<Interior>
{
    new Interior()
    {
        Id = 1,
        Price = 1200M,
        Material = "Beige Fabric"
    },
    new Interior()
    {
        Id = 2,
        Price = 1200M,
        Material = "Charcoal Fabric"
    },
    new Interior()
    {
        Id = 3,
        Price = 3500,
        Material = "White Leather"
    },
    new Interior()
    {
        Id = 4,
        Price = 3000,
        Material = "Black Leather"
    }
};

List<Technology> technologies = new List<Technology>
{
    new Technology()
    {
        Id = 1,
        Price = 500M,
        Package = "Basic Package"
    },
    new Technology()
    {
        Id = 2,
        Price = 750M,
        Package = "Navigation Package"
    },
    new Technology()
    {
        Id = 3,
        Price = 1250M,
        Package = "Visiblity Package"
    },
    new Technology()
    {
        Id = 4,
        Price = 2000M,
        Package = "Ultra Package"
    }
};

List<Wheels> wheels = new List<Wheels>
{
    new Wheels()
    {
        Id = 1,
        Price = 750,
        Style = "17-inch Pair Radial"
    },
    new Wheels()
    {
        Id = 2,
        Price = 1000,
        Style = "17-inch Pair Radial Black"
    },
    new Wheels()
    {
        Id = 3,
        Price = 1500,
        Style = "18-inch Pair Spoke Silver"
    },
    new Wheels()
    {
        Id = 4,
        Price = 2000,
        Style = "18-inch Pair Spoke Black"
    }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/wheels", () =>
{
    return wheels;
});

app.MapGet("/technologies", () =>
{
    return technologies;
});

app.MapGet("/interiors", () =>
{
    return interiors;
});

app.MapGet("/paintcolors", () =>
{
    return paintColors;
});

app.Run();