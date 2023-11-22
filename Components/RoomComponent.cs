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



