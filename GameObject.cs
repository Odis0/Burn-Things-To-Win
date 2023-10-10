
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

    public T GetObjectComponentOfType<T>() where T : class
    {
        foreach (IComponent component in componentList)
        {
            if (component is T typedComponent)
            {
                return typedComponent;
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
