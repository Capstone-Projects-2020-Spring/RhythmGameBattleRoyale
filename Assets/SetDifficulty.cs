using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    public GameObject expert;
    public GameObject hard;
    public GameObject medium;
    public GameObject easy;
    // Start is called before the first frame update
    void Start()
    {


        expert.SetActive(false);
        hard.SetActive(false);
        medium.SetActive(false);
        easy.SetActive(false);
        
        string dif = PlayerPrefs.GetString("find");
        print(dif);
        if (dif.Contains("Expert")) {
            expert.SetActive(true);

        }
        if (dif.Contains("Hard"))
        {
            print("in Hard");
            hard.SetActive(true);

        }

        if (dif.Contains("Medium"))
        {
            medium.SetActive(true);

        }

        if (dif.Contains("Easy"))
        {
            easy.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
