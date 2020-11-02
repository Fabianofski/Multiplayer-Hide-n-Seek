using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraMovement : MonoBehaviour
{

    public GameObject Target;
    public float speed;

    void Awake()
    {
        PhotonView[] players = FindObjectsOfType<PhotonView>();
        foreach(PhotonView p in players)
        {
            if (p.IsMine)
                Target = p.gameObject;
        }
    }

    void Update()
    {
        if (!Target) return;

        Vector3 targetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
