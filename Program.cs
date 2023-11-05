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


