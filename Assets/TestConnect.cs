using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("connecting to server...");
        PhotonNetwork.NickName = MasterManager.GameSettings.Nickname;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "0.0.1";
    }
    
    public override void OnConnectedToMaster()
    {
        print("connected to server");
        print(PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconnected from server for reason " + cause.ToString());
    }

    public void disconnectPlayer()
    {
        PhotonNetwork.Disconnect();
        print("disconnected successfully");
    }
}
