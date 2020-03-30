﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartParser;

public class Reader : MonoBehaviour
{
    public GameObject[] inputButtonObjects;
    public GameObject noteObject;
    public GameObject musicObject;
    public AudioSource audioData;
    public float songTime;

    private InstantiatorScript[] noteSpawnerScripts;
    Song Holder;
    List<Note> track;
    float startTime;
    float oldTime = 0f;
    public float b;
    public float res;
    bool songStarted = false;
    public AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 0.0f;
        noteSpawnerScripts = new InstantiatorScript[inputButtonObjects.Length];

        

        string path = Application.dataPath;
        string name = PlayerPrefs.GetString("name");
        //print("name" +name);
        Holder = Parser.ChartReader(path +name);
        track = Holder.NoteTracksList.getExpert();
        res = float.Parse(Holder.MetaDataInfo.getResolution());
         b = (float)Holder.SyncTrackData[0].getDuration()/1000.0f;
      
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
        startTime += Time.deltaTime;

        if (startTime >= (((track[0].getTimeStamp() / res) * (60000.0f / b)) / 1000.0f))
        {
            check(track[0].getChord());
            print(startTime-oldTime);
            oldTime = startTime;
        }
        float playSongTime = songTime;// + noteObject.GetComponent<NoteScript>().speed*-.003f + 6.45f;
        if (!songStarted && startTime >= playSongTime) {
            startSong();
        }
    }

    public void startSong(){
        if (!songStarted) {
            if (PlayerPrefs.GetInt("clip") == 0)
            {
                musicObject.GetComponent<AudioSource>().clip = clip[0];
            }
            else if(PlayerPrefs.GetInt("clip") == 1)
            {

            }
            audioData.Play(0);
        }
        songStarted = true;
    }


    public void check(List<ButtonColor> chord)
    {
        foreach (ButtonColor color in chord)
        {
            switch (color)
            {
                case ButtonColor.Green:
                    noteSpawnerScripts[0].SpawnNote();
                    print("green");
                    break;
                case ButtonColor.Red:
                    noteSpawnerScripts[1].SpawnNote();
                    print("red");
                    break;
                case ButtonColor.Yellow:
                    noteSpawnerScripts[2].SpawnNote();
                    print("yellow");
                    break;
                case ButtonColor.Blue:
                    noteSpawnerScripts[3].SpawnNote();
                    print("blue");
                    break;
                case ButtonColor.Orange:
                    noteSpawnerScripts[4].SpawnNote();
                    print("orange");
                    break;
                default:

                    break;
            }
        }
        track.RemoveAt(0);

    }






}