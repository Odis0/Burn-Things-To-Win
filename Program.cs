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

public class PlayerUI
{
    GameObject player;
    WorldObject world;
    public PlayerUI(GameObject player, WorldObject world)
    { 
        this.player = player; 
        this.world = world;
        DisplayUITopLevel();
    }
    

    public void DisplayPlayerRoomName(GameObject player)
    {
        Console.WriteLine(world.GetObjectRoomFromObject(player).GetName());
    }

    public void DisplayUITopLevel()
    {
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerRoomName(player);
            Console.WriteLine();

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
            List<List<GameObject>> listOfAdjacentLocationLists = world.GetLocationListsAdjacentFromObject(player);
            List<List<GameObject>> nonNullLists = new List<List<GameObject>>();

            Console.WriteLine("Where would you like to move?\n");

            int i = 0;
            foreach (List<GameObject> selectedList in listOfAdjacentLocationLists)
            {
                if (selectedList.Count > 0 && selectedList[0] != null)
                {
                    Console.WriteLine($"{i}:{selectedList[0].GetName()}");
                    nonNullLists.Add(selectedList); // Add non-null lists to a new list
                    i++;
                }
            }

            Console.WriteLine($"{i}: Back");
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
        }
    }







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
