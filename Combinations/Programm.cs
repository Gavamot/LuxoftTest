using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinations.Data;
using Combinations.Interfaces;

namespace Combinations
{
    class Program
    {
        private IInputDataSource source;
        private IOutputDataAccept dataAssept;
        private ICombination algoritm;

        public Program(IInputDataSource source, ICombination algoritm, IOutputDataAccept dataAssept)
        {
            this.source = source;
            this.algoritm = algoritm;
            this.dataAssept = dataAssept;
        }

        public void Run()
        {
            var data = source.GetDataSorce();
            var res = algoritm.GetResult(data);
            dataAssept.Save(res);
        }
    }
}
