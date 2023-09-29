public class LocationComponent: GameObject, IComponent
{
    private int xLocation;
    private int yLocation;

    public int GetXLocation() { return xLocation; }
    public int GetYLocation() { return yLocation; }

    public void SetXLocation(int xLocation) { this.xLocation = xLocation; }

    public void SetYLocation(int yLocation) { this.yLocation = yLocation; }

    public void PrintObjectLocation()
    {
        Console.WriteLine($"({this.xLocation},{this.yLocation})");
    }
    public LocationComponent(int xLocation, int yLocation)
    {
        this.xLocation = xLocation;
        this.yLocation = yLocation;


    }



}
