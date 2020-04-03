using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlayerProps : MonoBehaviourPunCallbacks
{
    public List<Text> playerNames;
    
    void Start()
    {
        ExitGames.Client.Photon.Hashtable props = new ExitGames.Client.Photon.Hashtable();
        props.Add("Score", 0);
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        int score = (int)PhotonNetwork.LocalPlayer.CustomProperties["Score"];

        if (SceneManager.GetActiveScene().name == "MultiPlayerScene")
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
                {
                    for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
                    {
                        playerNames[i].text = PhotonNetwork.CurrentRoom.Players[i].NickName
                            + " " + PhotonNetwork.CurrentRoom.Players[i].CustomProperties["Score"];

                        /*Debug.Log("Player scores: " + PhotonNetwork.CurrentRoom.Players[i].NickName 
                        +" = " + PhotonNetwork.CurrentRoom.Players[i].CustomProperties["Score"]);*/
                        Debug.LogError("Player scores: " + PhotonNetwork.CurrentRoom.Players[i].NickName 
                                + " = " + PhotonNetwork.CurrentRoom.Players[i].CustomProperties["Score"]);
                    }
                }
            }
        }
    }

    private void Update()
    {
        
    }

}