using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Xml;


public class Player : MonoBehaviour
{

    public Rigidbody2D rbPlayer;

    public float moveSpeed = 5;


    public List<GameObject> crateObjects = new List<GameObject>();

    private List<Vector3> lastPositions = new List<Vector3>();

    private Vector2 moveDirection;

    public Animator animator;

    void Start()
    {
    }

    void Update()
    {
        ProcessInputs();
    }


    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rbPlayer.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }

    void ProcessInputs()
    {
        Debug.Log("Process");
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
}