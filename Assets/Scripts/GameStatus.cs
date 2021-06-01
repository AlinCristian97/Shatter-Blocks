using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] private float _gameSpeed = 1f;
    [SerializeField] private int _pointsPerBlockDestroyed = 83;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    [SerializeField] private int _currentScore = 0; //debug

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false); //bugfix (score not updating after scene load)
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _scoreText.text = _currentScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = _gameSpeed;
    }

    public void AddToScore()
    {
        _currentScore += _pointsPerBlockDestroyed;
        _scoreText.text = _currentScore.ToString();
    }
}