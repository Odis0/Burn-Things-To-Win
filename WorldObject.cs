using System.ComponentModel.DataAnnotations;

public class WorldObject
{
    private List<GameObject>[,] worldArray;

    public enum Direction
    {
        North,
        South,
        East,
        West
    }

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

    public List<AdjacentLocationListWithDirection> GetLocationListsAdjacentFromObject(GameObject gameObject)
    {
        LocationComponent objectLocationComponent = gameObject.GetObjectLocationComponent();
        int currentXCoordinate = objectLocationComponent.GetXLocation();
        int currentYCoordinate = objectLocationComponent.GetYLocation();

        List<AdjacentLocationListWithDirection> listOfAdjacentLocationLists = new List<AdjacentLocationListWithDirection>();

        if ((currentXCoordinate - 1) >= 0) ///Checking West
        {
            listOfAdjacentLocationLists.Add(new AdjacentLocationListWithDirection
            {
                AdjacentLocationList = GetLocationListAtXYCoordinate(currentXCoordinate - 1, currentYCoordinate),
                Direction = WorldObject.Direction.West
            });
        }
        if ((currentXCoordinate + 1) < worldArray.GetLength(0) - 1) ///Checking East
        {
            listOfAdjacentLocationLists.Add(new AdjacentLocationListWithDirection
            {
                AdjacentLocationList = GetLocationListAtXYCoordinate(currentXCoordinate + 1, currentYCoordinate),
                Direction = WorldObject.Direction.East
            });
        }
        if ((currentYCoordinate - 1) >= 0) ///Checking South
        {
            listOfAdjacentLocationLists.Add(new AdjacentLocationListWithDirection
            {
                AdjacentLocationList = GetLocationListAtXYCoordinate(currentXCoordinate, currentYCoordinate - 1),
                Direction = WorldObject.Direction.South
            });
        }
        if ((currentYCoordinate + 1) < worldArray.GetLength(1) - 1) ///Checking North
        {
            listOfAdjacentLocationLists.Add(new AdjacentLocationListWithDirection
            {
                AdjacentLocationList = GetLocationListAtXYCoordinate(currentXCoordinate, currentYCoordinate + 1),
                Direction = WorldObject.Direction.North
            });
        }

        return listOfAdjacentLocationLists;
    }

    public class AdjacentLocationListWithDirection
    {
        public List<GameObject> AdjacentLocationList { get; set; }
        public WorldObject.Direction Direction { get; set; }
    }


    /*Old, without return the adjacent direction.
        public List<List<GameObject>> GetLocationListsAdjacentFromObject(GameObject gameObject)
    {
        LocationComponent objectLocationComponent = gameObject.GetObjectLocationComponent();
        int currentXCoordinate = objectLocationComponent.GetXLocation();
        int currentYCoordinate = objectLocationComponent.GetYLocation();

        List<List<GameObject>> listOfAdjacentLocationLists = new List<List<GameObject>>();

        if ((currentXCoordinate - 1) >= 0) ///Checking West
        {
            listOfAdjacentLocationLists.Add(GetLocationListAtXYCoordinate(currentXCoordinate - 1, currentYCoordinate));
        }
        if ((currentXCoordinate + 1) < worldArray.GetLength(0)-1) ///Checking East
        {
            listOfAdjacentLocationLists.Add(GetLocationListAtXYCoordinate(currentXCoordinate + 1, currentYCoordinate));
        }
        if ((currentYCoordinate - 1) >= 0  ) ///Checking South
        {
            listOfAdjacentLocationLists.Add(GetLocationListAtXYCoordinate(currentXCoordinate, currentYCoordinate - 1));
        }
        if ((currentYCoordinate + 1) < worldArray.GetLength(1)-1) ///Checking North
        {
            listOfAdjacentLocationLists.Add(GetLocationListAtXYCoordinate(currentXCoordinate, currentYCoordinate + 1));
        }
        return listOfAdjacentLocationLists;
    }
    */


    public List<GameObject> GetLocationListAtXYCoordinate(int x, int y)
    {
        return worldArray[x, y];
    }




    public List<GameObject> GetObjectLocationListInWorldArray(GameObject gameObject)
    {
        LocationComponent locationComponent = gameObject.GetObjectLocationComponent();
        List<GameObject> objectLocationList = worldArray[locationComponent.GetXLocation(), locationComponent.GetYLocation()];
        return objectLocationList;
    }

    public void MoveObjectByDirection(GameObject gameObject,Direction direction)
    {
        ///Remove from the current WorldArrayList.
        RemoveObjectFromWorld(gameObject);
        LocationComponent objectLocationComponent = gameObject.GetObjectLocationComponent();
        int currentXLocation = objectLocationComponent.GetXLocation();
        int currentYLocation = objectLocationComponent.GetYLocation();


        if (direction == Direction.North) {
            if ((currentYLocation + 1) < worldArray.GetLength(1) - 1) ///Checking North
            {
            objectLocationComponent.SetYLocation(currentYLocation += 1);
            } }
        if (direction == Direction.South) {
            if ((currentYLocation - 1) >= 0) ///Checking South
            {
                objectLocationComponent.SetYLocation(currentYLocation += -1);
            } }
        if (direction == Direction.East) {
            if ((currentXLocation + 1) < worldArray.GetLength(0) - 1) ///Checking East
            {
                objectLocationComponent.SetXLocation(currentXLocation += 1);
            } }
        if (direction == Direction.West) 
        {
            if ((currentXLocation - 1) >= 0) ///Checking West
            {
                objectLocationComponent.SetXLocation(currentYLocation += -1);
            } }

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


    /* This function doesn't work yet. It's meant to set an object's LocationComponent to equal the LocationComponent of the room it's currently in.
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