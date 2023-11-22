using System.Runtime.CompilerServices;

public class FlammableComponent : GameObject, IComponent
{
    private bool active = false;
    private int amountBurned = 0;

    public bool GetActive() { return active; }
    public void SetActive(bool onFire) {  active = onFire; }


    void IComponent.Update(GameObject? gameObject)
    {

        if (active)
        {
            switch (amountBurned)
            {
                case <4:
                    Console.WriteLine($"\nThe {gameObject.GetName()} continues to burn.");
                    amountBurned++;
                    break;
                case >= 4:
                    Console.WriteLine($"\nThe {gameObject.GetName()} burns to ash.");
                    active = false;
                    break;
                default:
                    break;
            }
        }
    }
}