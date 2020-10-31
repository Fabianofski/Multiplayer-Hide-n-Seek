using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;



public class NetworkManager : MonoBehaviourPunCallbacks
{

    public GameObject LobbyPanel;
    public GameObject MenuPanel;
    public TMP_InputField RoomCodeInput;

    public GameObject[] Players;

    #region ConnectToServer


    public void Connect()
    {
        Debug.Log("Connect to Server");
        PhotonNetwork.GameVersion = "v0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        LobbyPanel.SetActive(true);
        MenuPanel.SetActive(false);
        Debug.Log("Joined Lobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server: " + cause);
    }

    #endregion


    #region CreateRooms
    public void HostGame()
    {
        int roomCode = Random.Range(1, 10000);

        PhotonNetwork.CreateRoom(roomCode.ToString());
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomCodeInput.text);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Joining Room failed");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
        Debug.LogError(PhotonNetwork.CurrentRoom.Name);
    }

    #endregion
}
