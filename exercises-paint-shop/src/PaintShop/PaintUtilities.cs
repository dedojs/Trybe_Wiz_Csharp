namespace PaintShop.Test;

public static class PaintUtilities
{
    private static int _bucketSizeLitters = 20;
    public static int BucketSizeLiters
    {
        get
        {
            return _bucketSizeLitters;
        }
        set
        {
            _bucketSizeLitters = value;
        }
    }
    private static int _squareMetersPerLiter = 10;
    public static int SquareMetersPerLiter
    {
        get
        {
            return _squareMetersPerLiter;
        }
        set
        {
            _squareMetersPerLiter = value;
        }
    }
    
    public static int SquareMetersPerBucket
    {
        get
        {
            return BucketSizeLiters * SquareMetersPerLiter;
        }
    }

    public static int GetNeededPaintBuckets(double area)
    {
        var result = area / SquareMetersPerBucket; ;

        return (int)Math.Ceiling(result);
    }
    public static int GetNeededPaintBuckets(Wall wall)
    {
        //var area = wall.PaintableArea;
        //var result = area / SquareMetersPerBucket;
        //return (int)Math.Ceiling(result);

        return (int)Math.Ceiling(wall.PaintableArea / SquareMetersPerBucket);
    }
    public static int GetNeededPaintBuckets(Room room)
    {
        var area = room.TotalPaintableArea;
        var result = area / SquareMetersPerBucket;
        return (int)Math.Ceiling(result);
    }

    public static decimal CalculateCost(decimal cost, double area)
    {
        var bucket = GetNeededPaintBuckets(area);
        decimal result = cost * bucket;
        return result;
    }
    public static decimal CalculateCost(decimal cost, Wall wall)
    {
        var bucket = GetNeededPaintBuckets(wall);
        return cost * bucket;
    }

    public static decimal CalculateCost(decimal cost, Room room)
    {
        var bucket = GetNeededPaintBuckets(room);
        decimal result = cost * bucket;
        return result;
    }

}