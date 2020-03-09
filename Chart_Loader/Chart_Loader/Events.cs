using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart_Loader
{
    class Events
    {
        int timeStamp;
        string songPart;
        string identifier;


        public int getTimeStamp()
        {
            return timeStamp;
        }
        public string getSongPart()
        {
            return songPart;
        }
        public string getIdentifier()
        {
            return identifier;
        }

        public void SetTimeStamp(int Holder)
        {
            timeStamp = Holder;
        }
        public void setSongPart(string Holder)
        {
            songPart = Holder;
        }
        public void setIdentifier(string Holder)
        {
            identifier = Holder;
        }
    }
}
