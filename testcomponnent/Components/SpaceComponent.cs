using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burn_Things_To_Win
{
    public class SpaceComponent : PositionComponent
    {
        static int openId = 0;

        public SpaceComponent()
        {
            positionId = openId;
            openId++;
        }

        public PositionComponent newSpace()
        {    
            return new PositionComponent(openId++);
        }

    }
}
