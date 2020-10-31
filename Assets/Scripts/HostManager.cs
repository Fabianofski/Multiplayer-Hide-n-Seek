using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HostManager : MonoBehaviour
{

    public GameObject HostPanel;

    void Awake()
    {
        HostPanel.SetActive(PhotonNetwork.IsMasterClient);
    }

}
