using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class control_teacher : MonoBehaviour
{
    [SerializeField] private InputAction _up = null;
    [SerializeField] private InputAction _down = null;
    [SerializeField] private InputAction _left = null;
    [SerializeField] private InputAction _right = null;

    float _horizontal = 0;
    public float Speed = 1f;
    public Rigidbody _RigidBody;
    public Animator _Animator;
    private bool isFacingRight = true;

    private void OnEnable()
    {
        _left.Enable();
        _right.Enable();
    }

    private void OnDisable()
    {
        _left.Disable();
        _right.Disable();
    }

    void Start()
    {
        _RigidBody = GetComponent<Rigidbody>();
        _Animator = GetComponent<Animator>();

        _right.performed += context => _horizontal = 1;
        _right.canceled += context => _horizontal = 0;

        _left.performed += context => _horizontal = -1;
        _left.canceled += context => _horizontal = 0;

    }
    void Update()
    {
        if (!isFacingRight && _horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && _horizontal < 0f)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector2 vel_x = new Vector2(_horizontal * Speed, _RigidBody.velocity.y);
        _RigidBody.velocity = vel_x;
        _Animator.SetFloat("Speed", Mathf.Abs(vel_x.x));
    }

    private void Jump()
    {

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}

