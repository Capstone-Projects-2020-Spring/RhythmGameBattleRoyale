using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtonHandler : MonoBehaviour
{
    public void NextScene(){
        SceneManager.LoadScene("SettingsScene");
    }
}
