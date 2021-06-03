using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] private float _gameSpeed = 1f;
    [SerializeField] private int _pointsPerBlockDestroyed = 83;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private bool _isAutoPlayEnabled;
    
    [SerializeField] private int _currentScore = 0; //Serialized for debug

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
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

    public void ResetGame()
    {
        Destroy(gameObject);   
    }

    public bool IsAutoPlayEnabled()
    {
        return _isAutoPlayEnabled;
    }
}