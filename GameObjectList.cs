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

        Room entrance = new Room("Entrance", 0, 0, "You stand in the entryway of an ancient and eerie house.");
        Room livingRoom = new Room("Living Room", 0, 1, "Dust covers the furniture in this living room, though 'living' isn't the first word you'd associate with this forsaken place.");
        Room den = new Room("Den", 1, 0, "This study was once a place where serious work was done. The only laborers here now are spiders, diligently spinning their cobwebs.");
        Room kitchen = new Room("Kitchen", 1, 1, "This kitchen isn't exactly what you'd call 'hygenic,' though food was definitely prepared here at some point.");
        Room clownHole = new Room("Clown Hole", 0, 2, "This is the clown's evil place of evil.");

        ///Define RoomConnections Maybe? I don't know if I want to force all connections to be explicit.


        ///AddRoomsToObjectList

        gameObjectList.Add(entrance);
        gameObjectList.Add(livingRoom);
        gameObjectList.Add(den);
        gameObjectList.Add(kitchen);
        gameObjectList.Add(clownHole);


        ///Objects


        gameObjectList.Add(new Item("Chair", new FlammableComponent()));
        gameObjectList.Add(new Item("Armoire", new FlammableComponent()));
        gameObjectList.Add(new Player("Investigator", 0, 0));
        gameObjectList.Add(new Character("Creepy Clown", 0, 0, new FlammableComponent()));



        GetGameObjectList();


    }

}
