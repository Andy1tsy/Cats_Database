using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_Database
{
     public interface ISaveLoadable
    {
         void Save();
         void Load();
    }
}
