using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinMatchButtonHandler : MonoBehaviour
{
    public void NextScene(){
        SceneManager.LoadScene("LobbyJoinScene");
    }
}
