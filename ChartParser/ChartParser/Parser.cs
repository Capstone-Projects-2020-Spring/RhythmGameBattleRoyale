using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChartParser
{
    public class Parser
    {
        public static List<object> ChartReader(string FilePath)
        {
            Parser par = new Parser();
            NoteHolder NoteTracksList = new NoteHolder();
            Song SongData = new Song();
            List<SyncTrack> SyncTrackData = new List<SyncTrack>();
            List<Events> EventData = new List<Events>();
            List<object> CompleteData = new List<object>();
            string line;
            /*MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(FilePath));

            System.IO.StreamReader file =
                new System.IO.StreamReader(memoryStream);*/

            string text = File.ReadAllText(FilePath);
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length - 1; i++)
            {
               lines[i] = lines[i].Trim('\r');
            }

                for (int i = 0; i<lines.Length-1; i++)
                {
                    if (lines[i] == "[Song]")
                    {
                        SongData = parseSong(i,lines);
                    }
                    else if (lines[i] == "[SyncTrack]")
                    {
                        SyncTrackData = parseSyncTrack(i, lines);
                    }
                    else if (lines[i] == "[Events]")
                    {
                        EventData = parseEvents(i, lines);
                    }
                    else if (lines[i] == "[ExpertSingle]")
                    {
                        NoteTracksList.setExpert(parseNotes(i, lines, "Expert"));
                    }
                    else if (lines[i] == "[HardSingle]")
                    {
                        NoteTracksList.setHard(parseNotes(i, lines, "Hard"));
                    }
                    else if (lines[i] == "[MediumSingle]")
                    {
                        NoteTracksList.setMedium(parseNotes(i, lines, "Medium"));
                    }
                    else if (lines[i] == "[EasySingle]")
                    {
                        NoteTracksList.setEasy(parseNotes(i, lines, "Easy"));
                    }
                    System.Console.WriteLine(lines);
                }
            
            CompleteData.Add(SongData);
            CompleteData.Add(SyncTrackData);
            CompleteData.Add(EventData);
            CompleteData.Add(NoteTracksList);

            return CompleteData;




        }



        public static Song parseSong(int number, string[] lines)
        {
            Song S = new Song();

            number = number + 2;
            for (int i = number; i < lines.Length - 1; i++)
            {

                if (lines[i] == "}")
                {
                    return S;
                }


                string[] seperated = lines[i].Split('=');
                seperated[0] = seperated[0].Replace("\t", string.Empty).Replace(" ", string.Empty);
                seperated[1] = seperated[1].Remove(0, 1);
                seperated[1] = seperated[1].Trim('"');

                if ("Name" == seperated[0])
                {
                    S.setName(seperated[1]);
                }
                else if ("Artist" == seperated[0])
                {
                    S.setArtist(seperated[1]);
                }
                else if ("Charter" == seperated[0])
                {
                    S.setCharter(seperated[1]);
                }
                else if ("Offset" == seperated[0])
                {
                    S.setOffset(seperated[1]);
                }
                else if ("Resolution" == seperated[0])
                {
                    S.setResolution(seperated[1]);
                }
                else if ("PLayer2" == seperated[0])
                {
                    S.setPlayer2(seperated[1]);
                }
                else if ("Difficulty" == seperated[0])
                {
                    S.setDifficulty(seperated[1]);
                }
                else if ("PreviewStart" == seperated[0])
                {
                    S.setPreviewStart(seperated[1]);
                }
                else if ("PreviewEnd" == seperated[0])
                {
                    S.setPreviewEnd(seperated[1]);
                }
                else if ("Genre" == seperated[0])
                {
                    S.setGenre(seperated[1]);
                }
                else if ("MediaType" == seperated[0])
                {
                    S.setMediaType(seperated[1]);
                }
                else
                {
                    S.setMusicStream(seperated[1]);
                }
            }
            return null;
        }



        public static List<SyncTrack> parseSyncTrack(int number, string[] lines)
        {
            List<SyncTrack> SyncTrackList = new List<SyncTrack>();
            int timeStampTemp;
            int durationTemp;
            number = number + 2;
            for (int i = number; i < lines.Length - 1; i++)
            {

                if (lines[i] == "}")
                {
                    return SyncTrackList;
                }

                SyncTrack ST = new SyncTrack();


                string[] seperated = lines[i].Split('=');
                seperated[0] = seperated[0].Replace("\t", string.Empty).Replace(" ", string.Empty);
                seperated[1] = seperated[1].Remove(0, 1);

                string[] SyncTrackInfo = seperated[1].Split(' ');
                timeStampTemp = int.Parse(seperated[0]);
                durationTemp = int.Parse(SyncTrackInfo[1]);

                ST.SetTimeStamp(timeStampTemp);
                ST.setDuration(durationTemp);
                ST.setIdentifier(SyncTrackInfo[0]);

                SyncTrackList.Add(ST);
            }
            return null;
        }

        public static List<Events> parseEvents(int number, string[] lines)
        {
            List<Events> EventsList = new List<Events>();
            int timeStampTemp;
            number = number + 2;
            for (int i = number; i < lines.Length - 1; i++)
            {

                if (lines[i] == "}")
                {
                    return EventsList;
                }

                Events E = new Events();


                string[] seperated = lines[i].Split('=');
                seperated[0] = seperated[0].Replace("\t", string.Empty).Replace(" ", string.Empty);
                seperated[1] = seperated[1].Remove(0, 1);

                string[] EventInfo = seperated[1].Split('"');
                timeStampTemp = int.Parse(seperated[0]);

                E.SetTimeStamp(timeStampTemp);
                E.setSongPart(EventInfo[1]);
                E.setIdentifier(EventInfo[0].Trim());

                EventsList.Add(E);
                
            }
            return null;
        }




        public static List<Note> parseNotes(int number, string[] lines, string difficulty)
        {
            List<Note> ListTemp = new List<Note>();
            int timeStampTemp;
            bool multipleNote = false;

            number = number+2;
            for (int i = number; i < lines.Length - 1; i++)
            {

                if (lines[i] == "}")
                {
                    return ListTemp;
                }

                string[] seperated = lines[i].Split('=');
                seperated[0] = seperated[0].Replace("\t", string.Empty).Replace(" ", string.Empty);
                seperated[1] = seperated[1].Remove(0, 1);
                string[] noteInfo = seperated[1].Split(' ');

                if (noteInfo[0] == "N")
                {
                    timeStampTemp = int.Parse(seperated[0]);
                    Note NoteTemp = new Note();

                    //check t=if listnit empty if not empty check if timestapm = get the last note in list else create new note

                    if (ListTemp == null)
                    {
                        NoteTemp.setTimeStamp(int.Parse(seperated[0]));
                    }
                    if (ListTemp.Any())
                    {
                        if (timeStampTemp == ListTemp.Last().getTimeStamp())
                        {
                            NoteTemp = ListTemp.Last();
                            multipleNote = true;
                        }
                    }
                    if (!multipleNote)
                    {
                        NoteTemp.setTimeStamp(int.Parse(seperated[0]));
                        NoteTemp.setDuration(int.Parse(noteInfo[2]));
                    }

                    if (noteInfo[1] == "0")
                    {
                        NoteTemp.getChord().Add(ButtonColor.Red);
                    }
                    else if (noteInfo[1] == "1")
                    {
                        NoteTemp.getChord().Add(ButtonColor.Green);

                    }
                    else if (noteInfo[1] == "2")
                    {
                        NoteTemp.getChord().Add(ButtonColor.Yellow);

                    }
                    else if (noteInfo[1] == "3")
                    {
                        NoteTemp.getChord().Add(ButtonColor.Blue);

                    }
                    else if (noteInfo[1] == "4")
                    {
                        NoteTemp.getChord().Add(ButtonColor.Orange);
                    }
                    /*  else if (noteInfo[1] == "5")
                      {
                          NoteTemp.setType("Force");
                      }
                      else if (noteInfo[1] == "6")
                      {
                          NoteTemp.setType("Open");
                      }
                      else if (noteInfo[1] == "7")
                      {
                          NoteTemp.setType("Tap");
                      } */

                    if (!multipleNote)
                    {
                        ListTemp.Add(NoteTemp);
                    }
                    multipleNote = false;
                }
            }

            return null;
        }
    }
}
