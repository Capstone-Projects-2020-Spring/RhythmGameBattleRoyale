using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    public AudioSource music;

    public bool startPlaying;

    public BeatScroller BS;


    public static GameManager instance;

    public int currentScore;
    public int ScorePerNote = 100;
    public int goodHit = 125;
    public int perfectHit = 150;

    public Text scoreText;
    public Text multiplier;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshold;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text= "Score: 0" ;
        currentMultiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                BS.hasStarted = true;

                music.Play();

            }
        }
    }

    //checks if the note was hit and adds a multiplier and to the score text
    public void NoteHit()
    {
        Debug.Log("Hit!");

        if (currentMultiplier - 1 < multiplierThreshold.Length)
        {
            multiplierTracker++;

            if (multiplierThreshold[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiplier.text = "Multiplier: x" + currentMultiplier;


       // currentScore += ScorePerNote * currentMultiplier;
        scoreText.text = "Score: "+ currentScore;

    }

    public void NormalHit()
    {
        currentScore += ScorePerNote * currentMultiplier;
        NoteHit();

    }

    public void GoodHit()
    {
        currentScore += goodHit * currentMultiplier;
        NoteHit();
    }
    public void PerfectHit()
    {
        currentScore += perfectHit * currentMultiplier;
        NoteHit();
    }
    public void NoteMiss()
    {
        Debug.Log("Miss!");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplier.text = "Multiplier: x" + currentMultiplier;


    }

}
