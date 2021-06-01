using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Components
    private Rigidbody2D _rigidbody;
    
    // Config parameters
    [SerializeField] private Paddle _paddle;

    // State parameters
    private Vector2 _paddleToBallVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _paddleToBallVector = transform.position - _paddle.transform.position;
        _rigidbody.simulated = false; // TODO: Find a better solution for fixing the bug
    }

    private void Update()
    {
        Transform paddleTransform = _paddle.transform;
        
        var paddlePos = new Vector2(paddleTransform.position.x, paddleTransform.position.y);
        transform.position = paddlePos + _paddleToBallVector;
    }
}
