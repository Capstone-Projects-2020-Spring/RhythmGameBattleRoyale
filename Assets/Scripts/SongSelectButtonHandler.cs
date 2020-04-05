using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelectButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        SceneManager.LoadScene("SinglePlayerScene");
    }

    public void namePasser(string name)
    {

        PlayerPrefs.SetString("name", name);
    }
    public void audioNumber(int clip)
    {

        PlayerPrefs.SetInt("clip", clip);
    }
}