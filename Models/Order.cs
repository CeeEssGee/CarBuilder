namespace CarBuilderAPI.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int WheelId { get; set; }
    public int TechnologyId { get; set; }
    public int PaintId { get; set; }
    public int InteriorId { get; set; }
    public Wheels Wheels { get; set; }
    public Technology Technology { get; set; }
    public Paint Paint { get; set; }
    public Interior Interior { get; set; }
    public bool Fulfilled { get; set; }
    public Decimal TotalCost
    {
        get
        {
            decimal totalCost = 0;
            if (Interior?.Price != null && Paint?.Price != null && Technology?.Price != null && Wheels?.Price != null)
            {
                totalCost = Interior.Price + Paint.Price + Technology.Price + Wheels.Price;
                return totalCost;
            }
            else
            {
                return totalCost;
            }
        }
    }
}