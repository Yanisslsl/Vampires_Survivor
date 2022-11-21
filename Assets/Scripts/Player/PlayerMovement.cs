using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    PlayerControls controls;
    float direction = 0;
    public Rigidbody2D playerRB;
    int speed = 200;
    // Start is called before the first frame update
    Vector2 movement = Vector2.zero;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();


        controls.Player.Move.performed += ctx =>
        {
            movement = ctx.ReadValue<Vector2>();
            Debug.Log(movement);
        };
    }

    private void Update()
    {

        //movement = controls.Move.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();

    }

    void FixedUpdate()
    {
        MoveX();

    }
    void MoveX()
    {
        playerRB.MovePosition(playerRB.position + movement * 5f * Time.fixedDeltaTime);

        //animator.SetFloat("speed", 1);
    }


}
