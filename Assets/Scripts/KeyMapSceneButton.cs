using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyMapSceneButton : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene("KeyMapScene");
    }
}
