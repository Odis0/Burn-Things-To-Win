using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

GameObject playerRoom;

while (true)
{
    playerRoom = world.GetObjectRoomFromObject(playerObject);
    Console.WriteLine(playerRoom.GetName());
    Console.ReadLine();
    world.MoveObjectBetweenWorldArrayLists(playerObject, worldArray[0, 1]);

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


        ///Rooms
        gameObjectList.Add(new GameObject(name:"Entrance",componentList: new IComponent[] {new LocationComponent(0,0)}));
        gameObjectList.Add(new GameObject(name: "Living Room", componentList: new IComponent[] { new LocationComponent(0, 1) }));
        
        
        ///Objects
        gameObjectList.Add(new GameObject(name: "Investigator", componentList: new IComponent[] { new LocationComponent(0, 0), new PlayerComponent() }));
        gameObjectList.Add(new GameObject(name: "Chair", componentList: new IComponent[] { new FlammableComponent() }));
        gameObjectList.Add(new GameObject(name: "Armoire", componentList: new IComponent[] { new FlammableComponent() }));

        GetGameObjectList();
    
    
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

    public void AddObjectToWorldWithXY(GameObject gameObject, int xLocation, int yLocation)
    {
        worldArray[xLocation, yLocation].Add(gameObject);
    }

    public void AddObjectToWorldWithWorldArrayList(GameObject gameObject, List<GameObject> targetWorldArrayList)
    {
        targetWorldArrayList.Add(gameObject);
    }

    public void RemoveObjectFromWorld(GameObject gameObject)
    {
        List<GameObject> objectLocation = GetObjectLocationListInWorldArray(gameObject);
        objectLocation.Remove(gameObject);
    }

    public List<GameObject> GetObjectLocationListInWorldArray(GameObject gameObject)
    {
        LocationComponent locationComponent = gameObject.GetObjectLocationComponent();
        List<GameObject> objectLocationList = worldArray[locationComponent.GetXLocation(), locationComponent.GetYLocation()];
        return objectLocationList;
    }

    public void MoveObjectBetweenWorldArrayLists(GameObject gameObject, List<GameObject> targetLocationList)///Moves an object from one location list to another in the world array and sets their LocationComponent to equal that of the room they're now in.
    {
        ///Remove from the current WorldArrayList.
        RemoveObjectFromWorld(gameObject);

        ///Set gameObject LocationComponent to the LocationComponent of the new room.
        LocationComponent objectLocationComponent = gameObject.GetObjectLocationComponent();
        LocationComponent targetLocationComponent = GetRoomLocationComponentFromLocationList(targetLocationList);
        objectLocationComponent.SetXLocation(targetLocationComponent.GetXLocation());
        objectLocationComponent.SetYLocation(targetLocationComponent.GetYLocation());

        ///Add to new targetLocationList
        AddObjectToWorldWithWorldArrayList(gameObject, targetLocationList);


    }
    
    public GameObject GetObjectRoomFromObject(GameObject gameObject)
    {
        List<GameObject> objectLocationList = GetObjectLocationListInWorldArray(gameObject);
        return objectLocationList[0];
    }


    public LocationComponent GetRoomLocationComponentFromLocationList(List<GameObject> locationList)
    {
        GameObject targetRoom = locationList[0];
        LocationComponent targetLocationComponent = targetRoom.GetObjectLocationComponent();
        return targetLocationComponent;    
    }


    /* This function doesn't work yet.
    public void SetObjectLocationComponentToCurrentRoomLocationComponent(GameObject gameObject) ///This is to make it so that an object can set their location component to the coordinates of the room they're in.
    {
        List<GameObject> gameObjectLocationList = GetObjectLocationListInWorldArray(gameObject);
        LocationComponent roomLocationComponent = GetRoomLocationComponentFromLocationList(gameObjectLocationList);


        foreach (IComponent component in gameObject.GetComponentList())
        {
            if (component is LocationComponent locationComponent)
            {
                locationComponent = roomLocationComponent;
            }

        }
        gameObject.AddNewComponentToObjectComponentList(roomLocationComponent);
    }

    */

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

                    AddObjectToWorldWithXY(obj, xLocation, yLocation);

                }
            }
        }


    }
}