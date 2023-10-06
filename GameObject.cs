
using System.Runtime.CompilerServices;

public class GameObject : IComponent
{
    private string name;
    private List<IComponent> componentList = new List<IComponent>();



    public string GetName()
    {
        return name;
    }

    public List<IComponent> GetComponentList()
    {
        return componentList;
    }

    public void Update(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public void AddNewComponentToObjectComponentList(IComponent component)
    {
        componentList.Add(component);
    }

    public void MoveObjectByDirection(WorldObject.Direction direction, WorldObject worldObject)
    {
        switch (direction)
        {
            case WorldObject.Direction.East:
                GetObjectLocationComponent().MoveEast(this, worldObject);
                break;
            case WorldObject.Direction.West:
                GetObjectLocationComponent().MoveWest(this, worldObject);
                break;
            case WorldObject.Direction.South:
                GetObjectLocationComponent().MoveSouth(this, worldObject);
                break;
            case WorldObject.Direction.North:
                GetObjectLocationComponent().MoveNorth(this, worldObject);
                break;
            default:
                break;
        }
             
        
    }

    public LocationComponent GetObjectLocationComponent()
    {
        foreach (IComponent component in componentList)
        {
            if (component is LocationComponent locationComponent)
            {
                return locationComponent;
            }

        }
        return null;
    }
    public GameObject(string name = "", params IComponent[] componentList)
    {
        this.name = name;
        this.componentList.AddRange(componentList);

    }
}
