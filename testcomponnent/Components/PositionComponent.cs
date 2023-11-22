using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burn_Things_To_Win
{
    public class PositionComponent : Component
    {
        public int positionId;

        public PositionComponent()
        {
            positionId = 0;
        }
        public PositionComponent(int positionId)
        {
            this.positionId = positionId;
        }
    }
}
