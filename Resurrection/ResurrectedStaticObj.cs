using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.Resurrection
{
    class ResurrectedStaticObj
    {
        public static ResurrectedStaticObj resurrectedReference = null;
        ~ResurrectedStaticObj()            
        {
            resurrectedReference = this;
        }
    }
}
