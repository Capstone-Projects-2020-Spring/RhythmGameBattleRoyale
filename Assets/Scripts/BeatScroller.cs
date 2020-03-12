using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;
    public bool hasStarted;

    public void getBPM()
    {
        //beatTempo = Song.getResolution();
    }
   
    // Start is called before the first frame update
    void Start()
    {
        //needs bpm input
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
          /*  if (Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime,0f);
        }
    }
}
