using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;

    [SerializeField] private float speed, rotationSpeed, jumpForce;
/*    [SerializeField] private Transform target;
    [SerializeField] private Transform groundPoint;*/

    static public GameObject playerObject;
    private float distToGround;
    public float _moveX, _moveY;

    private Rigidbody _rb;
    //private Animator _anim;
    public Collider _playerCollider;
    void Start()
    {
        playerObject = gameObject.GetComponent<GameObject>();
        _rb = GetComponent<Rigidbody>();
        _playerCollider = GetComponent<Collider>();
        distToGround = _playerCollider.bounds.extents.y;
        //_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxis("Vertical");
        PhysicalMove();
    }

    void PhysicalMove()
    {
        Vector3 physicsMove = transform.forward * _moveY * speed + transform.right * _moveX * speed;
        physicsMove.y = _rb.velocity.y;
        _rb.velocity = physicsMove;
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1)))
        {
            return true;
        }
        return false;
    }

}

