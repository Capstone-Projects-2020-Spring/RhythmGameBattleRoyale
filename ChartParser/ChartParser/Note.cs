using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ChartParser
{
    public class Note
    {
        public int timestamp = -1;
        public int duration;
        public string type = "Normal";
        List<ButtonColor> chord = new List<ButtonColor>();



        public int getTimeStamp()
        {
            return timestamp;
        }
        public int getDuration()
        {
            return duration;
        }
        public string getType()
        {
            return type;
        }
        public List<ButtonColor> getChord()
        {
            return chord;
        }

        public void setTimeStamp(int holder)
        {
            timestamp = holder;
        }
        public void setDuration(int holder)
        {
            duration = holder;
        }
        public void setType(string holder)
        {
            type = holder;
        }
        public void setChord(List<ButtonColor> holder)
        {
            chord = holder;
        }
    }
}
