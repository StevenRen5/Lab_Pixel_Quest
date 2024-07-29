using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{   //components
    private Rigidbody2D _rigidbody2D;

    // Forces
    public float jumpForce = 10; //jumping
    public float fallForce = 2;  //falling
    private Vector2 _gravityVector; //for falling faster

    // Capsule 
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    // Water Check
    private bool _waterCheck; //checking the type of floor
    private string _waterTag = "Water";

    // Ground Check
    public Transform feetCollider; //interacting w/ the ground
    public LayerMask groundMask;
    private bool _groundCheck; //checking the type of floor



    // Sets gravity vector and connects components
    void Start()
    {
        _gravityVector = new Vector2(0, -Physics2D.gravity.y); //new vector for falling faster 
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is touching ground
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position, new Vector2(1, 1f), CapsuleDirection2D.Horizontal, 0, groundMask);

        // Checks if player is trying to jump/can jump
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck)) //player jump when touching ground/water by pressing space
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        // Checks if the gravity should be getting faster
        if (_rigidbody2D.velocity.y < 0 && !_waterCheck)  //when velocity is < 0, falling gets faster (velocity is subtracted every frame)
        {
            _rigidbody2D.velocity -= _gravityVector * (fallForce * Time.deltaTime);
        }
    }

    // Checks if player is in water
    private void OnTriggerEnter2D(Collider2D collision) //when player enters water, the check is turned on (player can jump)
    {
        if (collision.tag == _waterTag) 
        {
            _waterCheck = true;
        }
    }

    // Checks if player left water
    private void OnTriggerExit2D(Collider2D collision) // player exits water, the check is turned off (player cannot jump)
    {
        if (collision.tag == _waterTag)
        {
            _waterCheck = false;
        }
    }
}
