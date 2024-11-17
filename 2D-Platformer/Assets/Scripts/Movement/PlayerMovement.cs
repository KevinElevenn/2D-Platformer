using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float _jumpForce = 3f;
    // idk why our move is in a float it works i guess,
    private float _move;
    [SerializeField] private float _moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: update to use new unity input system
        // getting the Axis input from project settings unity shitty old input system
        _move = Input.GetAxis("Horizontal");
        // applies a velocity to our player rigidbody by multipling ouor move speed and updaing our y axis velocity to move the player.
        rb.velocity = new Vector2(_move * _moveSpeed, rb.velocity.y);

        // will check everframe for the jump input
        if (Input.GetButtonDown("Jump"))
        {
            // rb is our player's Rigidbody and we are appling a force to it in the x axis using the _jumpForce float to multiply it to make the player move up
            rb.AddForce(new Vector2(rb.velocity.x, _jumpForce));
        }
    }
}
