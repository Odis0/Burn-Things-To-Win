using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burn_Things_To_Win
{
    public class PlayerComp : Component
    {
        public int locationId;

        public PlayerComp()
        {
            this.locationId = 0;
        }
        public PlayerComp(int locationId)
        {
            this.locationId = locationId;
        }
    }
}
