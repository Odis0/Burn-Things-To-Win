using Burn_Things_To_Win;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

Manager manager = new Manager();
Entity e = manager.AddAndGetEntity();
manager.AddComponentToEntity(e, new PlayerComp());
manager.AddComponentToEntity(e, new PositionComponent(0));
manager.AddComponentToEntity(e, new DescriptionComponent("I am the player"));

manager.AddSystem(new DescriptionSystem(e));

e = manager.AddAndGetEntity();
manager.AddComponentToEntity(e, new PositionComponent(0));
manager.AddComponentToEntity(e, new DescriptionComponent("This is a creepy clown man A"));

e = manager.AddAndGetEntity();
manager.AddComponentToEntity(e, new PositionComponent(0));
manager.AddComponentToEntity(e, new RoomComp());
manager.AddComponentToEntity(e, new DescriptionComponent("This is a description Room A"));

e = manager.AddAndGetEntity();
manager.AddComponentToEntity(e, new PositionComponent(1));
manager.AddComponentToEntity(e, new RoomComp());
manager.AddComponentToEntity(e, new DescriptionComponent("This is a description Room B"));

e = manager.AddAndGetEntity();
manager.AddComponentToEntity(e, new PositionComponent(1));
manager.AddComponentToEntity(e, new DescriptionComponent("This is a creepy clown man B"));

manager.Update(0);

Console.In.ReadLine();

/*
//
Room entrance   = new Room("Entrance", 0, 0, "You stand in the entryway of an ancient and eerie house.");
Room livingRoom = new Room("Living Room", 0, 1, "Dust covers the furniture in this living room, though 'living' isn't the first word you'd associate with this forsaken place.");
Room den        = new Room("Den", 1, 0, "This study was once a place where serious work was done. The only laborers here now are spiders, diligently spinning their cobwebs.");
Room kitchen    = new Room("Kitchen", 1, 1, "This kitchen isn't exactly what you'd call 'hygenic,' though food was definitely prepared here at some point.");
Room clownHole  = new Room("Clown Hole", 0, 2, "This is the clown's evil place of evil.");

entrance.componentList.Insert(0, new SpaceComponent(entrance));
livingRoom.componentList.Insert(0, new SpaceComponent(livingRoom));
den.componentList.Insert(0, new SpaceComponent(den));
kitchen.componentList.Insert(0, new SpaceComponent(kitchen));
clownHole.componentList.Insert(0, new SpaceComponent(clownHole));

GameObject? playerObject = new Player("Investigator", ((SpaceComponent)entrance.componentList[0]), 0, 0);
((SpaceComponent)entrance.componentList[0]).gameObjectList.Add(playerObject);
//((SpaceComponent)entrance.componentList[0]).gameObjectList.Add(new Character("Creepy Clown", 0, 0, new FlammableComponent()));

entrance.componentList.Add(new NauticalComponent(livingRoom, "north"));
entrance.componentList.Add(new NauticalComponent(den, "east"));
livingRoom.componentList.Add(new NauticalComponent(entrance, "south"));
livingRoom.componentList.Add(new NauticalComponent(clownHole, "north"));
livingRoom.componentList.Add(new NauticalComponent(kitchen, "east"));
clownHole.componentList.Add(new NauticalComponent(livingRoom, "south"));
den.componentList.Add(new NauticalComponent(kitchen, "north"));
den.componentList.Add(new NauticalComponent(entrance, "west"));
kitchen.componentList.Add(new NauticalComponent(livingRoom,  "west"));
kitchen.componentList.Add(new NauticalComponent(den, "south"));

GameObject World = new GameObject("Game World");
World.componentList.Insert(0, new SpaceComponent(World));

SpaceComponent WorldSpace = (SpaceComponent)World.componentList[0];

entrance.parentSpace = WorldSpace;
livingRoom.parentSpace = WorldSpace;
den.parentSpace = WorldSpace;
kitchen.parentSpace = WorldSpace;
clownHole.parentSpace = WorldSpace;

WorldSpace.gameObjectList.Add(entrance);
WorldSpace.gameObjectList.Add(livingRoom);
WorldSpace.gameObjectList.Add(den);
WorldSpace.gameObjectList.Add(kitchen);
WorldSpace.gameObjectList.Add(clownHole);


//WorldSpace.gameObjectList.Add(new Item("Chair", new FlammableComponent()));
//WorldSpace.gameObjectList.Add(new Item("Armoire", new FlammableComponent()));

//

//GameObjectList gameObjectList = new GameObjectList(); ///Initialize gameObjectList.
//GameObject? playerObject = entrance.componentList[0]; ///Get the object with the PlayerComponent component.
PlayerUI playerUI = new PlayerUI(playerObject, WorldSpace);
*/
///Messing Around
/*
GameObject VorpalSword = new Item("Vorpal Sword", new AttackableComponent());
IActionComponent weaponComponent = VorpalSword.GetObjectComponentOfType<AttackableComponent>();
weaponComponent.Activate(VorpalSword,new Armoire());
Console.WriteLine(weaponComponent.GetName());
*/
// GameObject lighter = new Item("Lighter", new IgniteComponent());
// IActionComponent igniteComponent = lighter.GetObjectComponentOfType<IgniteComponent>();
// igniteComponent.Activate(lighter, WorldSpace.GetGameObjectList()[8]);

///GameObject playerRoom;
/*
while (true)
{
    //LocationComponent playerLocation = playerObject.GetObjectLocationComponent();
    //int currentPlayerXLocation = playerLocation.GetXLocation();
    //int currentPlayerYLocation = playerLocation.GetYLocation();
    //List<GameObject> objectsAtCurrentLocation = WorldSpace.GetObjectsAtLocation(currentPlayerXLocation, currentPlayerYLocation);
    GameObject? currentRoom = playerObject.parentSpace.parentObject;
    

    DescriptionInRoomComponent? currentRoomDescription = currentRoom.GetObjectComponentOfType<DescriptionInRoomComponent>();

    ///This shows the name of the current room.
    Console.WriteLine($"{currentRoom.GetName()}\n");

    ///This displays the description of the current Room. Probably should be in the playerUI, but it's not yet.
    Console.WriteLine(currentRoomDescription.GetDescription());
    
    ///This displays the names of the objects in the player's current room.
    Console.WriteLine("\nYou see the following here:");
    foreach (GameObject obj in playerObject.parentSpace.gameObjectList)
    {
        if (obj != currentRoom && obj != playerObject)
        {
            Console.WriteLine($"{obj.GetName()}\n");
        }
    }
        ///This goes into the context menus.
        playerUI.DisplayUITopLevel();

        ///Run update function after a turn is taken.
        foreach (GameObject gameObject in WorldSpace.GetGameObjectList())
        {
            gameObject.Update();
        }
    }



public interface IActionComponent:IComponent
{
    
    void Activate(GameObject ownerObject);
    void Activate(GameObject object1,  GameObject object2);
    string GetName();
}

public class AttackableComponent : GameObject,IActionComponent
{


    public void Activate(GameObject ownerObject, GameObject targetObject)
    {
        Console.WriteLine($"You attack the {targetObject.GetName()} with {ownerObject.GetName()}");
    }

    public void Activate(GameObject ownerObject)
    {
        throw new NotImplementedException();
    }

    public AttackableComponent(): base("Attack") { }


}

public class IgniteComponent : GameObject, IActionComponent
{
    public void Activate(GameObject ownerObject)
    {
        throw new NotImplementedException();
    }

    public void Activate(GameObject ownerObject, GameObject targetObject)
    {
        FlammableComponent targetComponent = targetObject.GetObjectComponentOfType<FlammableComponent>();
        if(targetComponent != null)
        {
            Console.WriteLine($"You set the {targetObject.GetName()} on fire with your {ownerObject.GetName()}!");
            targetComponent.SetActive(true);
        }
    }
}*/