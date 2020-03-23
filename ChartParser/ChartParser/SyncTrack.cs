using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartParser
{
    public class SyncTrack
    {
        int timeStamp;
        int duration;
        string identifier;


        public int getTimeStamp()
        {
            return timeStamp;
        }
        public int getDuration()
        {
            return duration;
        }
        public string getIdentifier()
        {
            return identifier;
        }

        public void SetTimeStamp(int Holder)
        {
            timeStamp = Holder;
        }
        public void setDuration(int Holder)
        {
            duration = Holder;
        }
        public void setIdentifier(string Holder)
        {
            identifier = Holder;
        }
    }
}
