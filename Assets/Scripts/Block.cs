using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;

    private Level _level;
    private GameSession _gameSession;

    private void Awake()
    {
        _level = FindObjectOfType<Level>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        _level.CountBreakableBlocks();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        _gameSession.AddToScore();
        
        AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        _level.BlockDestroyed();
    }
}