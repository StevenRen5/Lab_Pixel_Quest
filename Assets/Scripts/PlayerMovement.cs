using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;                        // Controls player physics
   public SpriteRenderer _spriteRenderer;                  // Controls player image
    public float xMultiplier = 4;                   // Controls layer X speed
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get player movement from player button presss
        float xMovement = Input.GetAxis("Horizontal");

        // Flips the sprite if movement is 0 or more, keep it flipped if it's less than 0
        if (xMovement >= 0) { _spriteRenderer.flipX = true;}
        else { _spriteRenderer.flipX = false;}

        // Give the speed to the rigidbody
        _rigidbody2D.velocity = new Vector2(xMultiplier * xMovement, _rigidbody2D.velocity.y);
    }
}
