using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ReturnData
    {
        public int choise { get; }
        public string find { get; }
        public ReturnData(int _choise, string _find)
        {
            choise = _choise;
            find = _find;
        }
    }
}
