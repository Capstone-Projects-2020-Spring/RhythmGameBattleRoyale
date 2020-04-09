using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.UtilityScripts;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject connectButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = "RGBR#" + Random.Range(1000, 9999);
        PhotonNetwork.LocalPlayer.SetScore(0);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Update()
    {
        List<int> scores = new List<int>();

        if (PhotonNetwork.CurrentRoom != null)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                PhotonNetwork.LoadLevel(6);

                for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
                {
                    /*Debug.LogError("Players in lobby: #" + i + " - " + PhotonNetwork.CurrentRoom.Players[i].NickName
                        +", Score: " + PhotonNetwork.CurrentRoom.Players[i].GetScore());*/
                    Debug.LogError("Players in lobby: #" + i + " - " + PhotonNetwork.CurrentRoom.Players[i].NickName
                        + ", Score: " + PhotonNetwork.CurrentRoom.Players[i].GetScore());

                    scores.Add(PhotonNetwork.CurrentRoom.Players[i].GetScore());
                }
                /* scores.Sort();

                var sortedScores = string.Join(", ", scores);
                //Debug.Log(scores);
                Debug.LogError("Sorted scores: " + sortedScores);

                //Debug.Log("Lowest score: " + scores[0]);
                Debug.LogError("Lowest score: " + scores[0]);

                for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
                {
                    if (scores[0] == PhotonNetwork.CurrentRoom.Players[i].GetScore())
                    {
                        //Debug.Log(PhotonNetwork.CurrentRoom.Players[i] + " has been eliminated");
                        Debug.LogError(PhotonNetwork.CurrentRoom.Players[i] + " has been eliminated");

                    }
                } */
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        //Debug.Log("Player has connected to the Photon master server");
        Debug.LogError("Player has connected to the Photon master server");
        connectButton.SetActive(true);
    }

    public void OnConnectButtonClicked()
    {
        //Debug.Log("Attempting to connect to lobby");
        Debug.LogError("Attempting to connect to lobby");
        connectButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //Debug.Log("Joining a random lobby failed. No open lobbies available");
        Debug.LogError("No open lobbies available");
        CreateRoom();
    }

    void CreateRoom()
    {
        //Debug.Log("Trying to create a lobby");
        Debug.LogError("Trying to create a lobby");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Lobby " + randomRoomName, roomOptions);
        //Debug.Log("Lobby created");
        Debug.LogError("Lobby created");
    }

    public override void OnJoinedRoom()
    {
        //Debug.Log("Player is now in a lobby");
        Debug.LogError("Player is now in a lobby");
        //Debug.Log("Players in lobby: " + PhotonNetwork.CurrentRoom.PlayerCount);
        Debug.LogError("Players in lobby: " + PhotonNetwork.CurrentRoom.PlayerCount);
        //Debug.Log("Player name: " + PhotonNetwork.NickName);
        Debug.LogError("Player name: " + PhotonNetwork.NickName);
        //Debug.Log("Player score: " + PhotonNetwork.LocalPlayer.GetScore());
        Debug.LogError("Player score: " + PhotonNetwork.LocalPlayer.GetScore());
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //Debug.Log("Lobby could not be created because lobby with same name already exists.");
        Debug.LogError("Lobby could not be created because lobby with same name already exists.");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        //Debug.Log("Stopping search for lobbies");
        Debug.LogError("Stopping search for lobbies");
        cancelButton.SetActive(false);
        connectButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public void DisconnectPlayer()
    {
        PhotonNetwork.Disconnect();
        //Debug.Log("Disconnected");
        Debug.LogError("Disconnected");
    }
}