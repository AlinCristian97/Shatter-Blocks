using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //TODO: Improve by using relative values
    [SerializeField] private float _screenWidthInUnits = 16f;
    [SerializeField] private float _minX = 1f;
    [SerializeField] private float _maxX = 15f;

    private GameSession _gameSession;
    private Ball _ball;

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        var paddlePos = transform.position;
        
        var newPaddlePos = new Vector2(
            Mathf.Clamp(GetXPos(), _minX, _maxX),
            paddlePos.y
        );

        transform.position = newPaddlePos;
    }
    
    private float GetXPos(){
        if (_gameSession.IsAutoPlayEnabled())
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * _screenWidthInUnits;
        }
    }
}