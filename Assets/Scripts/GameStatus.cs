using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] private float _gameSpeed = 1f;
    [SerializeField] private int _pointsPerBlockDestroyed = 83;
    
    [SerializeField] private int _currentScore = 0; //debug
    
    private void Update()
    {
        Time.timeScale = _gameSpeed;
    }

    public void AddToScore()
    {
        _currentScore += _pointsPerBlockDestroyed;
    }
}