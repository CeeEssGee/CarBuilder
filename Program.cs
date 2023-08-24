using System.Net.NetworkInformation;
using CarBuilderAPI.Models;

List<Paint> paints = new List<Paint>
{
    new Paint()
    {
        Id = 1,
        Price = 350M,
        Color = "Silver"
    },
    new Paint()
    {
        Id = 2,
        Price = 400M,
        Color = "Midnight Blue"
    },
    new Paint()
    {
        Id = 3,
        Price = 450M,
        Color = "Firebrick Red"
    },
    new Paint()
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
        Name = "Beige Fabric"
    },
    new Interior()
    {
        Id = 2,
        Price = 1200M,
        Name = "Charcoal Fabric"
    },
    new Interior()
    {
        Id = 3,
        Price = 3500,
        Name = "White Leather"
    },
    new Interior()
    {
        Id = 4,
        Price = 3000,
        Name = "Black Leather"
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

List<Order> orders = new List<Order>
{

};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
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

app.MapGet("/paints", () =>
{
    return paints;
});

// app.MapGet("/orders", () =>
// {
//     foreach (Order order in orders)
//     {
//         order.Interior = interiors.FirstOrDefault(i => i.Id == order.InteriorId);
//         order.Wheels = wheels.FirstOrDefault(w => w.Id == order.WheelId);
//         order.Paint = paints.FirstOrDefault(p => p.Id == order.PaintId);
//         order.Technology = technologies.FirstOrDefault(t => t.Id == order.TechnologyId);
//     }
//     return Results.Ok(orders);
// });

app.MapGet("/orders", () =>
{
    List<Order> unfulfilledOrders = orders.Where(o => !o.Fulfilled).ToList();

    foreach (Order order in unfulfilledOrders)
    {
        order.Interior = interiors.FirstOrDefault(i => i.Id == order.InteriorId);
        order.Wheels = wheels.FirstOrDefault(w => w.Id == order.WheelId);
        order.Paint = paints.FirstOrDefault(p => p.Id == order.PaintId);
        order.Technology = technologies.FirstOrDefault(t => t.Id == order.TechnologyId);
    }
    return Results.Ok(unfulfilledOrders);
});

app.MapPost("/orders", (Order order) =>
{
    // create a new id
    order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
    order.Timestamp = DateTime.Now;
    orders.Add(order);
    return order;
});

app.MapPost("/orders/{orderId}/fulfill", (int orderId) =>
{
    Order orderToFulfill = orders.FirstOrDefault(o => o.Id == orderId);
    orderToFulfill.Fulfilled = true;
});

app.Run();