using System.ComponentModel;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


GameObjectList gameObjectList = new GameObjectList(); ///Initialize gameObjectList.
GameObject? playerObject = gameObjectList.GetPlayerObject(); ///Get the object with the PlayerComponent component.


///GameObject playerRoom;

while (true)
{
    LocationComponent playerLocation = playerObject.GetObjectLocationComponent();
    int currentPlayerXLocation = playerLocation.GetXLocation();
    int currentPlayerYLocation = playerLocation.GetYLocation();
    List<GameObject> objectsAtCurrentLocation = gameObjectList.GetObjectsAtLocation(currentPlayerXLocation, currentPlayerYLocation);
    GameObject? currentRoom = null;
    foreach (GameObject obj in objectsAtCurrentLocation)
    {
        if (obj.GetObjectComponentOfType<RoomComponent> != null)
        {
            currentRoom = obj; break;
        }
    }
    Console.WriteLine(currentRoom.GetName());
    Console.WriteLine();
    DescriptionInRoomComponent? descriptionInRoom = currentRoom.GetObjectComponentOfType<DescriptionInRoomComponent>();
    Console.WriteLine(descriptionInRoom.GetDescription());


    

    /*
    ///playerRoom = world.GetObjectRoomFromObject(playerObject);
    ///playerUI.DisplayPlayerRoomName(playerRoom.GetName());
    foreach (GameObject gameObject in gameObjectList.GetObjectsAtLocation(currentPlayerXLocation, currentPlayerYLocation))
    {
        Console.WriteLine(gameObject.GetName());
    }
    ///PlayerUI playerUI = new PlayerUI(playerObject, world);


    */
    Console.ReadLine();
}
    ///int playerInput1 = playerUI.GetPlayerInput();
    ///world.MoveObjectBetweenWorldArrayLists(playerObject, worldArray[0, 1]);








public class TakeableComponent:GameObject, IComponent
{

}

public class RoomComponent:GameObject, IComponent
{
    private List<GameObject> connectedRoomsList = new List<GameObject>();
    public List<GameObject> GetConnectedRooms()
    {
        return connectedRoomsList;
    }

    public void AddRoomsToConnectedRoomsList(params GameObject[] roomConnections)
    {
        foreach (GameObject room in roomConnections)
        {
            connectedRoomsList.Add(room);
        }
    }

    public RoomComponent(params GameObject[] objectList)
    {
        this.connectedRoomsList.AddRange(objectList);
    }



}



public class GameObjectList
{
    private List<GameObject> gameObjectList = new List<GameObject>();

    public List<GameObject> GetGameObjectList()
    {
        return gameObjectList;
    }

    public List<GameObject> GetObjectsAtLocation(int xLocation, int yLocation)
    {
        List<GameObject> objectsAtLocation = new List<GameObject>();

        foreach (GameObject obj in gameObjectList)
        {
            foreach (IComponent component in obj.GetComponentList())
            {
                if (component is LocationComponent)
                {
                    LocationComponent locationComponent = (LocationComponent)component;
                    if (locationComponent.GetXLocation() == xLocation && locationComponent.GetYLocation() == yLocation)
                    {
                        objectsAtLocation.Add(obj);
                    }
                }
            }
        }

        return objectsAtLocation;
    }


    public void AddDoubleRoomConnections(GameObject room1, GameObject room2)
    {

    }


    public GameObject GetPlayerObject()
        {
            foreach (GameObject obj in gameObjectList)
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
    


        public GameObjectList()
        {
        
        ///Define Rooms
        GameObject entrance = new GameObject(name: "Entrance", componentList: new IComponent[] { new LocationComponent(0, 0), new RoomComponent(), new DescriptionInRoomComponent("You stand in the entryway of an ancient and eerie house.") });
        GameObject livingRoom = new GameObject(name: "Living Room", componentList: new IComponent[] { new LocationComponent(0, 1), new RoomComponent(), new DescriptionInRoomComponent("Dust covers the furniture in this living room, though 'living' isn't the first word you'd associate with this forsaken place.") });
        GameObject den = new GameObject(name: "Den", componentList: new IComponent[] { new LocationComponent(1, 0), new RoomComponent(), new DescriptionInRoomComponent("This study was once a place where serious work was done. The only laborers here now are spiders, diligently spinning their cobwebs.") });
        GameObject kitchen = new GameObject(name: "Kitchen", componentList: new IComponent[] { new LocationComponent(2, 2), new RoomComponent(), new DescriptionInRoomComponent("This kitchen isn't exactly what you'd call 'hygenic,' though food was definitely prepared here at some point.") });

        ///Define RoomConnections


        ///AddRoomsToObjectList

            gameObjectList.Add(entrance);
            gameObjectList.Add(livingRoom);
            gameObjectList.Add(den);
            gameObjectList.Add(kitchen);


            ///Objects
            gameObjectList.Add(new GameObject(name: "Investigator", componentList: new IComponent[] { new LocationComponent(0, 0), new PlayerComponent() }));
            gameObjectList.Add(new GameObject(name: "Chair", componentList: new IComponent[] { new FlammableComponent() }));
            gameObjectList.Add(new GameObject(name: "Armoire", componentList: new IComponent[] { new FlammableComponent() }));

            GetGameObjectList();


        }

    
}


