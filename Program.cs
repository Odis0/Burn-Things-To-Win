using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


GameObjectList gameObjectList = new GameObjectList(); ///Initialize gameObjectList.
GameObject? playerObject = gameObjectList.GetPlayerObject(); ///Get the object with the PlayerComponent component.
WorldObject world = new WorldObject(3, 3, gameObjectList.GetGameObjectList()); ///Build the world with the objects in the gameObject list.
List<GameObject>[,] worldArray = world.GetWorldArray(); ///Save the worldArray in a variable that's easy to reference.


///GameObject playerRoom;

while (true)
{
    ///playerRoom = world.GetObjectRoomFromObject(playerObject);
    ///playerUI.DisplayPlayerRoomName(playerRoom.GetName());

    PlayerUI playerUI = new PlayerUI(playerObject, world);



    ///int playerInput1 = playerUI.GetPlayerInput();
    ///world.MoveObjectBetweenWorldArrayLists(playerObject, worldArray[0, 1]);

}








public class TakeableComponent:GameObject, IComponent
{

}




    public class GameObjectList
{
    private List<GameObject> gameObjectList = new List<GameObject>();

    public List<GameObject> GetGameObjectList()
    {
        return gameObjectList;
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
        gameObjectList.Add(new GameObject(name:"Entrance",componentList: new IComponent[] {new LocationComponent(0,0)}));
        gameObjectList.Add(new GameObject(name: "Living Room", componentList: new IComponent[] { new LocationComponent(0, 1) }));
        gameObjectList.Add(new GameObject(name: "Den", componentList: new IComponent[] { new LocationComponent(1, 0) }));
        gameObjectList.Add(new GameObject(name: "Kitchen", componentList: new IComponent[] { new LocationComponent(2, 2) }));


        ///Objects
        gameObjectList.Add(new GameObject(name: "Investigator", componentList: new IComponent[] { new LocationComponent(0, 0), new PlayerComponent() }));
        gameObjectList.Add(new GameObject(name: "Chair", componentList: new IComponent[] { new FlammableComponent() }));
        gameObjectList.Add(new GameObject(name: "Armoire", componentList: new IComponent[] { new FlammableComponent() }));

        GetGameObjectList();
    
    
    }

}
