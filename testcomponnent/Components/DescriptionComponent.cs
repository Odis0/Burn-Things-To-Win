using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burn_Things_To_Win
{
    public class DescriptionComponent : Component
    {
        public string text;
        public DescriptionComponent(string text)
        {
            this.text = text;
        }
    }
}
