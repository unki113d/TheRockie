using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;

    [SerializeField] private float speed, rotationSpeed, jumpForce;
    [SerializeField] private Transform target;
    [SerializeField] private Transform groundPoint;

    static public GameObject playerObject;
    private float distToGround;
    private float _moveX, _moveY;

    private Rigidbody _rb;
    private Animator _anim;
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
        GetDirection();
    }

    void GetDirection()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxis("Vertical");
        direction = transform.forward * _moveY + transform.right * _moveX;
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

