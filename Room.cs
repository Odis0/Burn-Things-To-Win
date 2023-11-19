public class Room : GameObject
{
    public Room(string name, int XCoordinate, int YCoordinate, string descriptionInRoom)
        : base(name, new LocationComponent(XCoordinate, YCoordinate), new RoomComponent(), new DescriptionInRoomComponent(descriptionInRoom))
    {
    }
}


