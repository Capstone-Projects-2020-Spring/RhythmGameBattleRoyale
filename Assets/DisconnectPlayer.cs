using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectPlayer : MonoBehaviour
{
    public void disconnectPlayer()
    {
        //PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        //Debug.Log("Disconnected");
        Debug.LogError("Disconnected");
        PhotonNetwork.LoadLevel(0);
    }
}
