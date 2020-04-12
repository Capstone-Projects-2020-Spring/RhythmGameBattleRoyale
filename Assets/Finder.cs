using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Finder : MonoBehaviour
{
 

    public void FindDifficulty()
    {
        

        string line;
        string dif = ""; ;
        string songPath = PlayerPrefs.GetString("name");
        string path = Application.streamingAssetsPath;
        string text = File.ReadAllText(path+songPath);
        string[] lines = text.Split('\n');

        for (int i = 0; i < lines.Length - 1; i++)
        {
            lines[i] = lines[i].Trim('\r');
            
        }

        for (int i = 0; i < lines.Length - 1; i++)
        {
          
            
            if (lines[i] == "[ExpertSingle]")
            {
                dif = dif + "Expert";
            }
            if (lines[i] == "[HardSingle]")
            {
                dif = dif + " Hard";

            }
            if (lines[i] == "[MediumSingle]")
            {
                dif = dif + " Medium";

            }
            if (lines[i] == "[EasySingle]")
            {
                dif = dif + " Easy";

            }
        }

        PlayerPrefs.SetString("find", dif);

    }
}
