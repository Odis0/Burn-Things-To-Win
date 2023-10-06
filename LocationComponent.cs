using System.Xml.Schema;
using static WorldObject;

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

    public void MoveNorth(GameObject gameObject, WorldObject worldObject)
    {
        WorldObject.Direction direction = WorldObject.Direction.North;
        ///yLocation += 1;
        worldObject.MoveObjectByDirection(gameObject, direction);

    }

    public void MoveSouth(GameObject gameObject, WorldObject worldObject)
    {
        WorldObject.Direction direction = WorldObject.Direction.South;
        ///yLocation += -1;
        worldObject.MoveObjectByDirection(gameObject, direction);

    }

    public void MoveEast(GameObject gameObject, WorldObject worldObject)
    {
        WorldObject.Direction direction = WorldObject.Direction.East;
        ///yLocation += 1;
        worldObject.MoveObjectByDirection(gameObject, direction);
    }

    public void MoveWest(GameObject gameObject, WorldObject worldObject)
    {
        WorldObject.Direction direction = WorldObject.Direction.West;
        ///xLocation += -1;
        worldObject.MoveObjectByDirection(gameObject, direction);
    }


}
