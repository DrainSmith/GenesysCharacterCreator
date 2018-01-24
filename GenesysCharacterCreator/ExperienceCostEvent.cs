using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesysCharacterCreator
{
    public class ExperienceCostEventArgs : EventArgs
    {
        public int Cost;

        public ExperienceCostEventArgs(int Cost)
        {
            this.Cost = Cost;
        }
    }
}
