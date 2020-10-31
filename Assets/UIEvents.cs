using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UIEvents : MonoBehaviour
{

    public void StartGame()
    {

        PhotonNetwork.LoadLevel("GameScene");
    }

}
