using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class UIEvents : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI CodeText;

    void Awake()
    {
        CodeText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public void StartGame()
    {

        PhotonNetwork.LoadLevel("GameScene");
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene(0);
    }

}
