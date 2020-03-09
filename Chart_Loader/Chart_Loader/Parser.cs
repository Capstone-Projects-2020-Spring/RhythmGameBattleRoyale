using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Chart_Loader
{
    class Parser
    {
       

        public List<object> ChartParser(string FilePath)
        {
            Parser par = new Parser();
            NoteHolder NoteTracksList = new NoteHolder();
            Song SongData = new Song();
            List<SyncTrack> SyncTrackData = new List<SyncTrack>();
            List<Events> EventData = new List<Events>();
            List<object> CompleteData = new List<object>();

            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(FilePath);
            while ((line = file.ReadLine()) != null)
            {
                if (line == "[Song]")
                {
                    SongData = par.parseSong(line, file);
                }
                else if (line == "[SyncTrack]")
                {
                    SyncTrackData = par.parseSyncTrack(line, file);
                }
                else if (line == "[Events]")
                {
                   EventData = par.parseEvents(line, file);
                }
                else if (line == "[ExpertSingle]")
                {
                    NoteTracksList.setExpert(par.parseNotes(line, file, "Expert"));
                }
                else if (line == "[HardSingle]")
                {
                    NoteTracksList.setHard(par.parseNotes(line, file, "Hard"));
                }
                else if (line == "[MediumSingle]")
                {
                    NoteTracksList.setMedium(par.parseNotes(line, file, "Medium"));
                }
                else if (line == "[EasySingle]")
                {
                    NoteTracksList.setEasy(par.parseNotes(line, file, "Easy"));
                }
                System.Console.WriteLine(line);
            }
            file.Close();

            CompleteData.Add(SongData);
            CompleteData.Add(SyncTrackData);
            CompleteData.Add(EventData);
            CompleteData.Add(NoteTracksList);

            return CompleteData;
          



        }



        public Song parseSong(string line, System.IO.StreamReader file)
        {
            Song S = new Song();

            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {

                if (line == "}")
                {
                    return S;
                }


                string[] seperated = line.Split('=');
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



        public List<SyncTrack> parseSyncTrack(string line, System.IO.StreamReader file)
        {
            List<SyncTrack> SyncTrackList = new List<SyncTrack>();
            int timeStampTemp;
            int durationTemp;

            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {

                if (line == "}")
                {
                    return SyncTrackList;
                }

                SyncTrack ST = new SyncTrack();


                string[] seperated = line.Split('=');
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

        public List<Events> parseEvents(string line, System.IO.StreamReader file)
        {
            List<Events> EventsList = new List<Events>();
            int timeStampTemp;

            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {

                if (line == "}")
                {
                    return EventsList;
                }

                Events E = new Events();


                string[] seperated = line.Split('=');
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




        public List<Note> parseNotes(string line, System.IO.StreamReader file , string difficulty)
        {
            List<Note> ListTemp = new List<Note>();
            int timeStampTemp;
            bool multipleNote = false;
            
            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {

                if (line == "}")
                {
                    return ListTemp;
                }

                string[] seperated = line.Split('=');
                seperated[0] = seperated[0].Replace("\t", string.Empty).Replace(" ", string.Empty);
                seperated[1] = seperated[1].Remove(0, 1);
                string[] noteInfo = seperated[1].Split(' ');

                if (noteInfo[0] == "N")
                {
                    timeStampTemp = int.Parse(seperated[0]);
                    Note NoteTemp  = new Note();
                    
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
