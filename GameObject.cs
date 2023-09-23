
public class GameObject: IAttribute  
{
    private string name;
    private List<IAttribute> attributeList = new List<IAttribute>();
    public string GetName()
    {
        return name;
    }

    public List<IAttribute> GetAttributeList()
    {
        return attributeList;
    }

    public void Activate(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public GameObject(string name, List<IAttribute> attributeList)
    {
        this.name = name;
        this.attributeList = attributeList;
    }
}
