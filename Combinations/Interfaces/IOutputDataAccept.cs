using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinations.Data;

namespace Combinations
{
    interface IOutputDataAccept
    {
        void Save(Output output);
    } 
}
