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
        Debug.Log("Scene changed to " + sceneToChange);
    }
}
