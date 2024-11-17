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
    private bool isGrounded;
    private int _jumpCount;
    [SerializeField] private int _maxJumps = 2;
    

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
        if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumps) // checks the jump count to allow fore double jump
        {
            // Apply a force to the Rigidbody2D to make the player jump
            rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse); // im pretty sure the 0 means the direction of the jump
            ++_jumpCount; // adds 1 to jump count
        }
    }

    // uses ColliderEnter to update grounded bool to true and resets jump count when grounded
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            Debug.Log("Grounded");
            isGrounded = true;
            Debug.Log("JumpsReset");
            _jumpCount = 0;
        }
    }

    // uses the exit of the collider to update Grounded bool to fales
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            Debug.Log("Ungrounded");
            isGrounded = false;
        }
    }
}
