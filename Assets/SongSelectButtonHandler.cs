using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelectButtonHandler : MonoBehaviour
{

    public void NextScene()
    {
        SceneManager.LoadScene("SinglePlayerScene");
        Debug.Log("Scene changed to SinglePlayerScene");
    }

    public void namePasser(string name)
    {
        PlayerPrefs.SetString("name", name);
        Debug.Log("Song name: " + nameFormat(name));
    }

    public void audioNumber(int clip)
    {
        PlayerPrefs.SetInt("clip", clip);
    }

    public string nameFormat(string name)
    {
        name = name.Remove(name.Length - 6, 6);
        name = name.Remove(0, 1);
        return name;
    }
}
