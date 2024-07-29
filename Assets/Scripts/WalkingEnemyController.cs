using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed;
    private int direction = 1; // enemy is moving in the + direction

    // Capsule
    public float CapsuleHeight = 0.25f;
    public float CapsuleRadius = 0.08f;

    // Ground Check
    public Transform feetCollider; //interacting w/ the ground
    public LayerMask groundMask;
    private bool _groundCheck; //checking the type of floor


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); // get component rigidbody to control velocity
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(speed * direction, _rigidbody2D.velocity.y); // adjust enemy's speed left/right; keep y constant

        // Checks if player is touching ground
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position, new Vector2(1, 1f), CapsuleDirection2D.Horizontal, 0, groundMask);

        if(!_groundCheck)
        {
            direction *= -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // changes body direction when comes in contact with objects (rect box collider)
    {
        direction *= -1;
        transform.localScale = new Vector3(direction, 1, 1); // turns player's faced direction when touched an object
    }
}
