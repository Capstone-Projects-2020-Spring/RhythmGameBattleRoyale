using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class PlayerProps : MonoBehaviourPunCallbacks
{
    public List<Text> playerNames;
    public List<Text> playerScores;
    public Text eliminationText;

    void Start()
    {
        List<int> scores = new List<int>();

        if (SceneManager.GetActiveScene().name == "MultiPlayerScene")
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
                {
                    for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
                    {
                        playerNames[i].text = PhotonNetwork.CurrentRoom.Players[i].NickName;
                        playerScores[i].text = (PhotonNetwork.CurrentRoom.Players[i].GetScore()).ToString();

                        scores.Add(PhotonNetwork.CurrentRoom.Players[i].GetScore());
                    }
                    scores.Sort();
                    for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
                    {
                        if (scores[0] == PhotonNetwork.CurrentRoom.Players[i].GetScore())
                        {
                            eliminationText.text = PhotonNetwork.CurrentRoom.Players[i].NickName + " has been eliminated";
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}