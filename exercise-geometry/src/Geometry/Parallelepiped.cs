namespace Geometry;
public class Parallelepiped
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Volume
    {
        get
        {
            return Width * Height * Depth;
        }
    }
    public Rectangle FaceA { get; set; }
    
    public Rectangle FaceB { get; set; }

    public Rectangle FaceC { get; set; }

    public double SurfaceArea
    {
        get
        {
            return 2 * (FaceA.Area + FaceB.Area + FaceC.Area);
        }
    }

    public Parallelepiped(double heigth, double width, double depth)
    {
        if (width <= 0 || heigth <= 0 || depth <= 0) 
        {
            throw new ArgumentException("All sides must be greater than zero");
        }

        Width = width;
        Height = heigth;
        Depth = depth;
        
        FaceA = new Rectangle(Width, Height);
        FaceB = new Rectangle(Height, Depth);
        FaceC = new Rectangle(Width, Depth);
    }


}
