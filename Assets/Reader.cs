using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartParser;

public class Reader : MonoBehaviour
{
    public GameObject[] inputButtonObjects;
    public GameObject musicObject;
    public AudioSource audioData;
    public float songTime;

    private InstantiatorScript[] noteSpawnerScripts;
    Song Holder;
    List<Note> track;
    List<SyncTrack> sync;
    float startTime;
    float oldTime = 0f;
    public float b;
    public float res;
    bool songStarted = false;
    private int measure = 0;
    public GameObject TapnoteObject;
    public GameObject StarnoteObject;
    public GameObject noteObject;
    public GameObject TapnoteObjectTemp;
    public GameObject noteObjectTemp;
    float starPowerTime = 0.0f;
    float timePLaceHolder;
    bool starPower = false;





    public AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.streamingAssetsPath;
        string name = PlayerPrefs.GetString("name");
        bool bpmCheck = true;

        startTime = 0.0f;
        
        noteSpawnerScripts = new InstantiatorScript[inputButtonObjects.Length];

        

       
        //print("name" +name);
        Holder = Parser.ChartReader(path +name);
        sync = Holder.SyncTrackData;
        SelectedDifficulty(PlayerPrefs.GetInt("DifSelected"));

        res = float.Parse(Holder.MetaDataInfo.getResolution());

        while (bpmCheck) {
            if (sync[0].getIdentifier() != "TS") {
                b = (float)sync[0].getDuration() / 1000.0f;
                bpmCheck = false;
            }
            sync.RemoveAt(0);

        }
      
        for (int i = 0; i < inputButtonObjects.Length; i++)
        {
            noteSpawnerScripts[i] = inputButtonObjects[i].GetComponent<InstantiatorScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        print(sync.Count);
        startTime += Time.deltaTime;
        if (sync.Count > 0 && sync[0].getIdentifier() == "TS")
        {
            sync.RemoveAt(0);
        }
        if(sync.Count > 0 && startTime >= calcTime(sync[0].getTimeStamp()))
        {
            b = (float)sync[0].getDuration()/1000;
            sync.RemoveAt(0);

        }
        
        if (track.Count>0 && startTime >= calcTime(track[0].getTimeStamp()))
        {
           // print(track[0].getType());
           if (starPower == true && startTime > starPowerTime)
            {
                starPower = false;
                TapnoteObject = TapnoteObjectTemp;
                noteObject = noteObjectTemp;

            }
            if (track[0].getType() == "Normal")
            {
                check(track[0].getChord(), noteObject);
            }
            else if (track[0].getType() == "Tap")
            {
                check(track[0].getChord(), TapnoteObject);
            }
            else if (track[0].getType() == "Star")
            {
                TapnoteObject = StarnoteObject;
                noteObject = StarnoteObject;
                starPower = true;
                timePLaceHolder = startTime;
                starPowerTime = (((track[0].getDuration() / res) * (60000.0f / b)) / 1000.0f) + timePLaceHolder;

                track.RemoveAt(0);
            }
            oldTime = startTime;
        }
        if (startTime >= calcTime((res * measure)))
        {
            measure++;
            noteSpawnerScripts[2].SpawnBar();
        }


        float playSongTime = songTime;// + noteObject.GetComponent<NoteScript>().speed*-.003f + 6.45f;
        if (!songStarted && startTime >= playSongTime) {
            startSong();
        }
    }

    public float calcTime(float value) {
        return (((value / res) * (60000.0f / b)) / 1000.0f);
    }

    public void startSong(){
        if (!songStarted) {
            if (PlayerPrefs.GetInt("clip") == 0)
            {
                musicObject.GetComponent<AudioSource>().clip = clip[0];
            }
            if(PlayerPrefs.GetInt("clip") == 1)
            {
                musicObject.GetComponent<AudioSource>().clip = clip[1];
            }
            if (PlayerPrefs.GetInt("clip") == 2)
            {
                musicObject.GetComponent<AudioSource>().clip = clip[2];

            }
            if (PlayerPrefs.GetInt("clip") == 3)
            {
                musicObject.GetComponent<AudioSource>().clip = clip[3];

            }
            if (PlayerPrefs.GetInt("clip") == 4)
            {
                musicObject.GetComponent<AudioSource>().clip = clip[4];

            }


            audioData.Play(0);
        }
        songStarted = true;
    }


    public void check(List<ButtonColor> chord, GameObject noteSkin)
    {
        foreach (ButtonColor color in chord)
        {
            switch (color)
            {
                case ButtonColor.Green:
                    noteSpawnerScripts[0].SpawnNote(noteSkin);
                    print("green");
                    break;
                case ButtonColor.Red:
                    noteSpawnerScripts[1].SpawnNote(noteSkin);
                    print("red");
                    break;
                case ButtonColor.Yellow:
                    noteSpawnerScripts[2].SpawnNote(noteSkin);
                    print("yellow");
                    break;
                case ButtonColor.Blue:
                    noteSpawnerScripts[3].SpawnNote(noteSkin);
                    print("blue");
                    break;
                case ButtonColor.Orange:
                    noteSpawnerScripts[4].SpawnNote(noteSkin);
                    print("orange");
                    break;
                default:

                    break;
            }
        }
        track.RemoveAt(0);

    }

    public void SelectedDifficulty(int selected)
    {
        switch (selected)
        {
            case 0:
                track = Holder.NoteTracksList.getExpert();

                break;
            case 1:
                track = Holder.NoteTracksList.getHard();

                break;
            case 2:
                track = Holder.NoteTracksList.getMedium();

                break;
            case 3:
                track = Holder.NoteTracksList.getEasy();

                break;
            default:

                break;
        }
    }






}
