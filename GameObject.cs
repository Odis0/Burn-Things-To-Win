
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

    public void Activate(GameObject gameObject)
    {
        throw new NotImplementedException();
    }


    public GameObject(string name = "", params IComponent[] componentList)
    {
        this.name = name;
        this.componentList.AddRange(componentList);

    }
}
