﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButtonHandler : MonoBehaviour
{
    public void NextScene(){
        SceneManager.LoadScene("MenuScene");
    }
}
