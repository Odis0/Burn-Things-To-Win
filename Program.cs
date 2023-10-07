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
    ///playerRoom = world.GetObjectRoomFromObject(playerObject);
    ///playerUI.DisplayPlayerRoomName(playerRoom.GetName());
    foreach (GameObject gameObject in gameObjectList.GetObjectsAtLocation(0, 0))
    {
        Console.WriteLine(gameObject.GetName());
    }
    ///PlayerUI playerUI = new PlayerUI(playerObject, world);

    Console.ReadLine();

    ///int playerInput1 = playerUI.GetPlayerInput();
    ///world.MoveObjectBetweenWorldArrayLists(playerObject, worldArray[0, 1]);

}








public class TakeableComponent:GameObject, IComponent
{

}

public class RoomComponent:GameObject, IComponent
{

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


            ///Rooms
            gameObjectList.Add(new GameObject(name: "Entrance", componentList: new IComponent[] { new LocationComponent(0, 0), new RoomComponent() }));
            gameObjectList.Add(new GameObject(name: "Living Room", componentList: new IComponent[] { new LocationComponent(0, 1), new RoomComponent() }));
            gameObjectList.Add(new GameObject(name: "Den", componentList: new IComponent[] { new LocationComponent(1, 0), new RoomComponent() }));
            gameObjectList.Add(new GameObject(name: "Kitchen", componentList: new IComponent[] { new LocationComponent(2, 2), new RoomComponent() }));


            ///Objects
            gameObjectList.Add(new GameObject(name: "Investigator", componentList: new IComponent[] { new LocationComponent(0, 0), new PlayerComponent() }));
            gameObjectList.Add(new GameObject(name: "Chair", componentList: new IComponent[] { new FlammableComponent() }));
            gameObjectList.Add(new GameObject(name: "Armoire", componentList: new IComponent[] { new FlammableComponent() }));

            GetGameObjectList();


        }

    
}
