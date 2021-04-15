using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Day
    {
        private String name;
        private List<int> hours;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<int> Hours
        {
            get { return hours; }
            set { hours = value; }
        }
    }
}
