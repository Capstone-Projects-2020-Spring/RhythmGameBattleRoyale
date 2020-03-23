using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class CreateLobbyMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Lobby", options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("lobby created successfully");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("lobby creation failed");
    }
}
