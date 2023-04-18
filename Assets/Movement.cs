using System;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Control Script/PlayerMovement")]
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxDifference = 0.2f;
    public float speed = 6.0f;
    public float jumpForce = 1f;
    private Rigidbody _rb;
    private Animator animator;
    private bool _isGrounded = false;
    
    private Vector3 _lastPoint = Vector3.down;

    void Start()
    {
        animator = GetComponent<Animator>();
       // _charController = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        if (deltaX != 0 || deltaZ != 0)
        {
            // animator.SetFloat("Speed", 1);
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
            // animator.SetFloat("Speed", 0);
        }

        var velocityX = transform.right * (speed * deltaX);
        var velocityZ = transform.forward * (speed * deltaZ);
        _rb.velocity = velocityX + velocityZ + new Vector3(0, _rb.velocity.y, 0);
        
        animator.SetBool("grounded", Grounded());
        if (!Input.GetButtonDown("Jump") || !Grounded()) return;
        // jump method
        
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool Grounded()
    {
        var hit = Physics.Raycast(new Ray(transform.position, Vector3.down), 1);
        return hit;
    }
    
}
