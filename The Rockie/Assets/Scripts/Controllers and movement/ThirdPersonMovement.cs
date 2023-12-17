using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [HideInInspector] public Vector3 direction;
    private float _horizontalInput, _verticalInput;
    CharacterController controller;

    [SerializeField] private float _groundOffset;
    [SerializeField] private LayerMask groundMask;
    private Vector3 _spherePos;

    [SerializeField] float _gravity = -9.81f;
    private Vector3 _velocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
    }

    void GetDirectionAndMove()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        direction = transform.forward * _verticalInput + transform.right * _horizontalInput;

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        _spherePos = new Vector3(transform.position.x, transform.position.y - _groundOffset, transform.position.z);
        if (Physics.CheckSphere(_spherePos, controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        return false;
    }
    void Gravity()
    {
        if(!IsGrounded())
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
        else if(_velocity.y < 0)
        {
            _velocity.y = -2;
        }

        controller.Move(_velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_spherePos, controller.radius - 0.05f);
    }
}
