using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;


GameObjectList gameObjectList = new GameObjectList();
GameObject? playerObject = GetPlayerObject(gameObjectList);

GameObject GetPlayerObject(GameObjectList gameObjectList)
{
    foreach (GameObject obj in gameObjectList.GetGameObjectList())
    {
        foreach (IComponent component in obj.GetComponentList())
        {
            if (component is PlayerComponent)
            {
                return obj;
            }
        }
    }

    // This message will be displayed only if no objects have the PlayerComponent.
    Console.WriteLine("No objects have the PlayerComponent component.");

    // Return null or throw an exception depending on your requirements.
    return null;
}



WorldObject world = new WorldObject(3, 3, gameObjectList.GetGameObjectList());
List<GameObject>[,] worldArray = world.GetWorldArray();



while (true)
{
    LocationComponent playerLocationComponent = playerObject.GetObjectLocationComponent();
    List<GameObject> playerLocation = worldArray[playerLocationComponent.GetXLocation(), playerLocationComponent.GetYLocation()];
    GameObject playerRoom = playerLocation[0];
    Console.WriteLine(playerRoom.GetName());
    Console.ReadLine();

}




public class GameObjectList
{
    private List<GameObject> gameObjectList = new List<GameObject>();

    public List<GameObject> GetGameObjectList()
    {
        return gameObjectList;
    }

    public GameObjectList()
    {
        gameObjectList.Add(new GameObject(name:"Entrance",componentList: new IComponent[] {new LocationComponent(0,0)}));
        gameObjectList.Add(new GameObject(name: "Investigator", componentList: new IComponent[] { new LocationComponent(0, 0), new PlayerComponent() }));
        gameObjectList.Add(new GameObject(name: "Chair", componentList: new IComponent[] { new FlammableComponent() }));
        gameObjectList.Add(new GameObject(name: "Armoire", componentList: new IComponent[] { new FlammableComponent() }));

        GetGameObjectList();
    
    
    }

}



public class MoveableComponent : GameObject, IComponent
{
    public void MoveObject(GameObject gameObject, int xDestination, int yDestination)
    {
        foreach (IComponent component in gameObject.GetComponentList())
        {
            if (component is LocationComponent locationComponent)
            {
                locationComponent.SetXLocation(xDestination);
                locationComponent.SetYLocation(yDestination);

            }

        }
    }
}

public class PlayerComponent : GameObject, IComponent
{

}

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



public class WorldObject
{
    private List<GameObject>[,] worldArray;


    public List<GameObject>[,] GetWorldArray()
    {
        return worldArray;
    }

    public void AddObjectToWorld(GameObject targetObject, int xLocation, int yLocation)
    {
        worldArray[xLocation, yLocation].Add(targetObject);
    }





    public WorldObject(int width, int height, List<GameObject> gameObjectList)
    {

        GameObject gameObject = new GameObject();

        worldArray = new List<GameObject>[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                worldArray[i, j] = new List<GameObject>();
            }
        }

        foreach (GameObject obj in gameObjectList)
        {
            List<IComponent> objectComponentList = obj.GetComponentList();
            foreach (IComponent component in objectComponentList)
            {
                if (component is LocationComponent locationComponent)
                {
                    int xLocation = locationComponent.GetXLocation();
                    int yLocation = locationComponent.GetYLocation();

                    AddObjectToWorld(obj, xLocation, yLocation);

                }
            }
        }


    }
}