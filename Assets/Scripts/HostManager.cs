using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class HostManager : MonoBehaviourPunCallbacks
{

    public GameObject HostPanel;

    void Awake()
    {
        EnableHostProperties();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        EnableHostProperties();
    }

    void EnableHostProperties()
    {
        HostPanel.SetActive(PhotonNetwork.IsMasterClient);
    }

}
