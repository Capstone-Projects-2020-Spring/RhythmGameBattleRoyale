using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart_Loader
{
    class NoteHolder
    {
        List<Note> Easy = new List<Note>();
        List<Note> Medium = new List<Note>();
        List<Note> Hard = new List<Note>();
        List<Note> Expert = new List<Note>();




        public List<Note> getEasy()
        {
            return Easy;
        }
        public List<Note> getMedium()
        {
            return Medium;
        }
        public List<Note> getHard()
        {
            return Hard;
        }
        public List<Note> getExpert()
        {
            return Expert;
        }
        public void setEasy(List<Note> holder)
        {
            Easy = holder;
        }
        public void setMedium(List<Note> holder)
        {
            Medium = holder;
        }
        public void setHard(List<Note> holder)
        {
            Hard = holder;
        }
        public void setExpert(List<Note> holder)
        {
            Expert = holder;
        }
    }
}
