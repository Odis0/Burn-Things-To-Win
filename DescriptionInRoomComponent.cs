public class DescriptionInRoomComponent : GameObject, IComponent ///This is a component that will convey the description of an object as it is seen in a room.
{
    private string description;
    public string GetDescription()
    {
        return description;
    }

    public DescriptionInRoomComponent(string description) { this.description = description; }


}
