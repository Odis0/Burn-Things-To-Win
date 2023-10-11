using System.ComponentModel;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


GameObjectList gameObjectList = new GameObjectList(); ///Initialize gameObjectList.
GameObject? playerObject = gameObjectList.GetPlayerObject(); ///Get the object with the PlayerComponent component.
PlayerUI playerUI = new PlayerUI(playerObject,gameObjectList);

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

    DescriptionInRoomComponent? currentRoomDescription = currentRoom.GetObjectComponentOfType<DescriptionInRoomComponent>();
    Console.WriteLine(currentRoomDescription.GetDescription());
    playerUI.DisplayUITopLevel();
}


    class PlayerUI

{
    GameObject playerObject;
    GameObjectList gameObjectList;
    public PlayerUI(GameObject playerObject, GameObjectList gameObjectList)
    {
        this.playerObject = playerObject;
        this.gameObjectList = gameObjectList;
    }

    public void DisplayUITopLevel()
    {
        while (true)
        {
          /*  Console.WriteLine();
            DisplayPlayerRoomName(player);
            Console.WriteLine();
          */

            int input0 = DisplayMainActionMenu();
            switch (input0)
            {
                case 0:
                    DisplayMoveActionMenu();
                    break;
                default:
                    Console.WriteLine("That's not a valid option.");
                    break;
            }

        }

    }


    public int DisplayMainActionMenu()
    {
        Console.WriteLine("What would you like to do?\n");
        Console.WriteLine("0: Move");
        int playerInput = GetPlayerInput();
        return playerInput;

    }

    public void DisplayMoveActionMenu()
    {
        while (true)
        {
            List<(GameObject, string)> adjacentRoomsWithDirections = gameObjectList.GetRoomObjectsAndCompassDirectionsAtAdjacentLocations(playerObject);

            Console.WriteLine("Where would you like to move?\n");

            int i = 0;
            foreach ((GameObject room, string direction) in adjacentRoomsWithDirections)
            {
                Console.WriteLine($"{i}:{room.GetName()} - {direction}");
                i++;
            }

            Console.WriteLine($"{i}: Back");
            int playerinput0 = GetPlayerInput();
        }
    }


    /*
    int playerInput = GetPlayerInput();
    if (playerInput >= 0 && playerInput < i)
    {
        world.MoveObjectBetweenWorldArrayLists(player, nonNullLists[playerInput]);
        break;
    }
    else if (playerInput == i)
    {
        break;
    }
    else
    {
        Console.WriteLine("You can't move there.");
    }
    */

    

    public int GetPlayerInput()
    {
        while (true)
        {
            string playerInput = Console.ReadLine();

            // Check if the input is empty (null or whitespace)
            if (string.IsNullOrWhiteSpace(playerInput))
            {
                Console.WriteLine("What was that?");
                continue; // Go back to the start of the loop
            }

            // Try to parse the input as an integer
            if (int.TryParse(playerInput, out int intValue))
            {
                return intValue; // Return the parsed integer
            }
            else
            {
                Console.WriteLine("Please input an integer");
            }
        }
    }
}
    /*
    ///playerRoom = world.GetObjectRoomFromObject(playerObject);
    ///playerUI.DisplayPlayerRoomName(playerRoom.GetName());
    foreach (GameObject gameObject in gameObjectList.GetObjectsAtLocation(currentPlayerXLocation, currentPlayerYLocation))
    {
        Console.WriteLine(gameObject.GetName());
    }
    ///PlayerUI playerUI = new PlayerUI(playerObject, world);


    */


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

    public List<GameObject> GetObjectsToNorthOfObject(GameObject gameObject)
    {
        LocationComponent locationComponent = gameObject.GetObjectLocationComponent();
        int xLocation = locationComponent.GetXLocation();
        int yLocation = locationComponent.GetYLocation();
        List<GameObject>? northObjectList = GetObjectsAtLocation(xLocation, yLocation+1);
        return northObjectList;
    }
    public List<GameObject> GetObjectsToSouthOfObject(GameObject gameObject)
    {
        LocationComponent locationComponent = gameObject.GetObjectLocationComponent();
        int xLocation = locationComponent.GetXLocation();
        int yLocation = locationComponent.GetYLocation();
        List<GameObject>? northObjectList = GetObjectsAtLocation(xLocation, yLocation-1);
        return northObjectList;
    }

    public List<GameObject> GetObjectsToEastOfObject(GameObject gameObject)
    {
        LocationComponent locationComponent = gameObject.GetObjectLocationComponent();
        int xLocation = locationComponent.GetXLocation();
        int yLocation = locationComponent.GetYLocation();
        List<GameObject>? northObjectList = GetObjectsAtLocation(xLocation+1, yLocation);
        return northObjectList;
    }
    public List<GameObject> GetObjectsToWestOfObject(GameObject gameObject)
    {
        LocationComponent locationComponent = gameObject.GetObjectLocationComponent();
        int xLocation = locationComponent.GetXLocation();
        int yLocation = locationComponent.GetYLocation();
        List<GameObject>? northObjectList = GetObjectsAtLocation(xLocation-1, yLocation);
        return northObjectList;
    }

    public List<GameObject> GetObjectsAtAdjacentLocations(GameObject gameObject)
    {
        List<GameObject>? objectsAtAdjacentLocations = new List<GameObject>();
        objectsAtAdjacentLocations.AddRange(GetObjectsToNorthOfObject(gameObject));
        objectsAtAdjacentLocations.AddRange(GetObjectsToSouthOfObject(gameObject));
        objectsAtAdjacentLocations.AddRange(GetObjectsToEastOfObject(gameObject));
        objectsAtAdjacentLocations.AddRange(GetObjectsToWestOfObject(gameObject));
        return objectsAtAdjacentLocations;

    }

    public List<(List<GameObject>, string)> GetObjectsAndCompassDirectionsAtAdjacentLocations(GameObject gameObject)
    {
        List<(List<GameObject>, string)> objectsAtAdjacentLocations = new List<(List<GameObject>, string)>();

        objectsAtAdjacentLocations.Add((new List<GameObject>(GetObjectsToNorthOfObject(gameObject)), "North"));
        objectsAtAdjacentLocations.Add((new List<GameObject>(GetObjectsToSouthOfObject(gameObject)), "South"));
        objectsAtAdjacentLocations.Add((new List<GameObject>(GetObjectsToEastOfObject(gameObject)), "East"));
        objectsAtAdjacentLocations.Add((new List<GameObject>(GetObjectsToWestOfObject(gameObject)), "West"));

        return objectsAtAdjacentLocations;
    }

    public List<(GameObject, string)> GetRoomObjectsAndCompassDirectionsAtAdjacentLocations(GameObject gameObject)
    {
        List<(GameObject, string)> roomsAndCompassDirectionsAtAdjacentLocations = new List<(GameObject, string)>();
        List<(List<GameObject>, string)> allObjectsAndDirectionsAtAdjacentLocations = GetObjectsAndCompassDirectionsAtAdjacentLocations(gameObject);

        foreach ((List<GameObject> objects, string direction) in allObjectsAndDirectionsAtAdjacentLocations)
        {
            GameObject room = GetObjectWithComponentOfTypeInList<RoomComponent>(objects);
            if (room != null)
            {
                roomsAndCompassDirectionsAtAdjacentLocations.Add((room, direction));
            }
        }

        return roomsAndCompassDirectionsAtAdjacentLocations;
    }



    public GameObject GetObjectWithComponentOfTypeInList<T>(List<GameObject> listOfGameObjects) where T : class
    {
        foreach (GameObject obj in listOfGameObjects)
        {
            T component = obj.GetObjectComponentOfType<T>();
            if (component != null)
            {
                return obj;
            }
        }

        return null; // Return null if no matching object is found
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



