using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NauticalComponent : IComponent
{
    public Room connectingRoom;
    public string direction;

    public NauticalComponent(Room cr, string dir)
    {
        connectingRoom = cr;
        direction = dir;
    }
    public void Update(GameObject? gameObject)
    {
    }

    
}

