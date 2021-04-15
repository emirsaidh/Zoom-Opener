using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Course
    {
        private String name;
        private String link;
        private String passcode;
        private List<Day> days;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Link
        {
            get { return link; }
            set { link = value; }
        }

        public String Passcode
        {
            get { return passcode; }
            set { passcode = value; }
        }

        public List<Day> Days
        {
            get { return days; }
            set { days = value; }
        }





    }


}
