using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlayerNames : MonoBehaviourPunCallbacks
{
    public List<Text> playerNames;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MultiPlayerScene")
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
                {
                    for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
                    {
                        playerNames[i].text = PhotonNetwork.CurrentRoom.Players[i].NickName;
                    }
                }
            }
        }
    }
}
