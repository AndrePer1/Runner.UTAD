using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utad.Lab.G02.Model
{
    public class erroOBJ :ApplicationException
    {
        public erroOBJ(string msg):base(msg) { }
    }
}
