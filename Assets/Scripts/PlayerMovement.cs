using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    PhotonView photonView;
    Rigidbody2D rb2d;
    float horizontalMovement;
    float verticalMovement;
    public float speed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
        enabled = photonView.IsMine;

        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        Movement();
        UpdateAnimation();
    }

    void Movement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if(horizontalMovement !=0 && verticalMovement != 0)
        {
            horizontalMovement *= 0.75f;
            verticalMovement *= 0.75f;
        }

        rb2d.velocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);
    }

    void UpdateAnimation()
    {
        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            animator.SetBool("Running", true);
            animator.SetFloat("horizontalInput", horizontalMovement);
            animator.SetFloat("verticalInput", verticalMovement);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
