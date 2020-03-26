using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public GameObject connectButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        connectButton.SetActive(true);
    }

    public void OnConnectButtonClicked()
    {
        Debug.Log("Attempting to connect to lobby");
        connectButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Joining a random lobby failed. No open lobbies available");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create a lobby");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 8 };
        PhotonNetwork.CreateRoom("Lobby " + randomRoomName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Player is now in a lobby");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Lobby could not be created because lobby with same name already exists.");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        Debug.Log("Stopping search for lobbies");
        cancelButton.SetActive(false);
        connectButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public void DisconnectPlayer()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("Disconnected");
    }
}
