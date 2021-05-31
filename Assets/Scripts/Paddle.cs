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

    private void Update()
    {
        var paddlePos = transform.position;
        
        float mousePosInUnits = Input.mousePosition.x / Screen.width * _screenWidthInUnits;

        var newPaddlePos = new Vector2(
            Mathf.Clamp(mousePosInUnits, _minX, _maxX),
            paddlePos.y
        );

        transform.position = newPaddlePos;
    }
}