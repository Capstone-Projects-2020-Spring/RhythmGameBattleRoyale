using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartParser
{
    public class MetaData
    {
       
            string Name, Artist, Charter, Offset, Resolution, Player2, Difficulty,
                PreviewStart, PreviewEnd, Genre, MediaType, MusicStream;


            public MetaData() { }

            public MetaData(string Name, string Artist, string Charter, string Offset,
                string Resolution, string Player2, string Difficulty, string PreviewStart,
                string PreviewEnd, string Genre, string MediaType, string MusicStream)
            {
                this.Name = Name;
                this.Artist = Artist;
                this.Charter = Charter;
                this.Offset = Offset;
                this.Resolution = Resolution;
                this.Player2 = Player2;
                this.Difficulty = Difficulty;
                this.PreviewStart = PreviewStart;
                this.PreviewEnd = PreviewEnd;
                this.Genre = Genre;
                this.MediaType = MediaType;
                this.MusicStream = MusicStream;
            }


            // Getters --------------------------------------------------------------------------------
            public string getName()
            {
                return Name;
            }
            public string getArtist()
            {
                return Artist;
            }
            public string getCharter()
            {
                return Charter;
            }
            public string getOffset()
            {
                return Offset;
            }
            public string getResolution()
            {
                return Resolution;
            }
            public string getPlayer2()
            {
                return Player2;
            }
            public string getDifficulty()
            {
                return Difficulty;
            }
            public string getPreviewStart()
            {
                return PreviewStart;
            }
            public string getPreviewEnd()
            {
                return PreviewEnd;
            }
            public string getGenre()
            {
                return Genre;
            }
            public string getMediaType()
            {
                return MediaType;
            }
            public string getMusicStream()
            {
                return MusicStream;
            }

            //setters -------------------------------------------------------------------------------
            public void setName(string value)
            {
                Name = value;
            }
            public void setArtist(string value)
            {
                Artist = value;
            }
            public void setCharter(string value)
            {
                Charter = value;
            }
            public void setOffset(string value)
            {
                Offset = value;
            }
            public void setResolution(string value)
            {
                Resolution = value;
            }
            public void setPlayer2(string value)
            {
                Player2 = value;
            }
            public void setDifficulty(string value)
            {
                Difficulty = value;
            }
            public void setPreviewStart(string value)
            {
                PreviewStart = value;
            }
            public void setPreviewEnd(string value)
            {
                PreviewEnd = value;
            }
            public void setGenre(string value)
            {
                Genre = value;
            }
            public void setMediaType(string value)
            {
                MediaType = value;
            }
            public void setMusicStream(string value)
            {
                MusicStream = value;
            }



        public override string ToString()
        {

            return Name + ", " + Artist + ", " + Charter + ", " + Offset + ", " + Resolution + ", " + Player2 + ", " + Difficulty + ", " +
                 PreviewStart + ", " + PreviewEnd + ", " + Genre + ", " + MediaType + ", " + MusicStream;
        }





    }
}
