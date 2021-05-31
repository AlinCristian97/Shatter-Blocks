using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _screenWidthInUnits = 16f;

    private void Update()
    {
        var paddleTransform = transform;
        
        float mousePosInUnits = Input.mousePosition.x / Screen.width * _screenWidthInUnits;
        var paddlePos = new Vector2(mousePosInUnits, paddleTransform.position.y);
        
        paddleTransform.position = paddlePos;
    }
}
