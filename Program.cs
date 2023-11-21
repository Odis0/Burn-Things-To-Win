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

///Messing Around
GameObject VorpalSword = new Item("Vorpal Sword", new AttackableComponent());
IActionComponent weaponComponent = VorpalSword.GetObjectComponentOfType<AttackableComponent>();
weaponComponent.Activate(VorpalSword,new Armoire());
Console.WriteLine(weaponComponent.GetName());


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

    ///This shows the name of the current room.
    Console.WriteLine($"{currentRoom.GetName()}\n");

    ///This displays the description of the current Room. Probably should be in the playerUI, but it's not yet.
    Console.WriteLine(currentRoomDescription.GetDescription());
    
    ///This displays the names of the objects in the player's current room.
    Console.WriteLine("\nYou see the following here:");
    foreach (GameObject obj in objectsAtCurrentLocation)
    {
        if (obj != currentRoom && obj != playerObject)
        {
            Console.WriteLine($"{obj.GetName()}\n");
        }
    }
        ///This goes into the context menus.
        playerUI.DisplayUITopLevel();

        ///Run update function after a turn is taken.
        foreach (GameObject gameObject in gameObjectList.GetGameObjectList())
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