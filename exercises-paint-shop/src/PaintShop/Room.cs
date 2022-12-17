namespace PaintShop;

public class Room
{
    public Wall[] Walls { get; }
    public double TotalPaintableArea { get; set; }

    public Room(params Wall[] walls)
    {
        Walls = walls;
        foreach (var item in Walls)
        {
            TotalPaintableArea += item.PaintableArea;
        }
    }

    
}