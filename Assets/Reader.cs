using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartParser;

public class Reader : MonoBehaviour
{
    public GameObject[] inputButtonObjects;

    private InstantiatorScript[] noteSpawnerScripts;
    Song Holder;
    List<Note> track;
    float startTime;
    public int b = 120;
    public int res = 192;


    // Start is called before the first frame update
    void Start()
    {
        startTime = 0.0f;
        noteSpawnerScripts = new InstantiatorScript[inputButtonObjects.Length];

        

        string path = Application.dataPath;

        Holder = Parser.ChartReader(path + "\\MEGALOVANIA.chart");
        track = Holder.NoteTracksList.getExpert();
        track.RemoveAt(0);

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

        if ((int)startTime == (((track[0].getTimeStamp() / res) * (60000 / b)) / 1000))
        {
            check(track[0].getChord());

        }
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
