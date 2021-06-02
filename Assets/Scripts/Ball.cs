using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // Components
    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;
    
    // Config parameters
    [SerializeField] private Paddle _paddle;
    [SerializeField] private float _xLaunch = 2f;
    [SerializeField] private float _yLaunch = 15f;
    [SerializeField] private AudioClip[] _ballSounds;
    [SerializeField] private float _randomFactor = 1f;

    // State parameters
    private Vector2 _paddleToBallVector;
    private bool _hasStarted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _paddleToBallVector = transform.position - _paddle.transform.position;
        _rigidbody.simulated = false; // TODO: Find a better solution for fixing the bug
    }

    private void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.simulated = true; // TODO: Find a better solution for fixing the bug
            _hasStarted = true;
            _rigidbody.velocity = new Vector2(_xLaunch, _yLaunch);
        }
    }

    private void LockBallToPaddle()
    {
        Transform paddleTransform = _paddle.transform;

        var paddlePos = new Vector2(paddleTransform.position.x, paddleTransform.position.y);
        transform.position = paddlePos + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float randomX = Random.Range(0f, _randomFactor);
        float randomY = Random.Range(0f, _randomFactor);
        Vector2 velocityTweak = new Vector2(randomX, randomY);
        
        if (_hasStarted)
        {
            int randomIndex = Random.Range(0, _ballSounds.Length);
            AudioClip clip = _ballSounds[randomIndex];
            
            _audioSource.PlayOneShot(clip);
            _rigidbody.velocity += velocityTweak;
        }
    }
}
