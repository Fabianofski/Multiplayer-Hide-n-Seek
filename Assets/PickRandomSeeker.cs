using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PickRandomSeeker : MonoBehaviour
{

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            int random = Random.Range(0, Players.Length);
            Debug.Log(Players[random].GetComponent<PhotonView>().Owner.NickName + " is Seeker");
        }
    }

}
