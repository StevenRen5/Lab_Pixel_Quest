using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator; // variable
    private Rigidbody2D _rigidbody2D; // variable
    private const string _isWalking = "isWalking"; // walking variable


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); // get component animator
        _rigidbody2D = GetComponent<Rigidbody2D>(); // get component rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.x != 0) // if velocity of rigidbody isn't = 0 then... { }
        {
            _animator.SetBool(_isWalking, true); // velocity is not 0 player will be animated to walk
        }
        else // animator will be false
        {
            _animator.SetBool(_isWalking, false); // velocity = 0 player will be animated to not walk
        }
    }
}
