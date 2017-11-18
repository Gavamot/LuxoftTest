using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinations.Data;

namespace Combinations.Interfaces
{
    interface ICombination
    {
        Output GetResult(Input input);
    }
}
