using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_ISENTREGA.IOC
{
   public class Container
    {
        public Container()
        {

        }
        public StandardKernel GetModules()
        {
            return new StandardKernel(new NinjectModulo());
        }
    }
}
