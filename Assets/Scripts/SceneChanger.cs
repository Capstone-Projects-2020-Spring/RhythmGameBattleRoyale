using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public String sceneToChange;
    public void NextScene()
    {
        SceneManager.LoadScene(sceneToChange);
    }
    public void namePasser(string name)
    {

        PlayerPrefs.SetString("name", name);
    }
    public void audioNumber(int clip)
    {

        PlayerPrefs.SetInt("clip", clip);
    }
    public void Difficulty(int dif)
    {
        PlayerPrefs.SetInt("DifSelected", dif);
    }
}