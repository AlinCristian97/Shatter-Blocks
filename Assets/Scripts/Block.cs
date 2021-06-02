using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;
    [SerializeField] private GameObject _blockSparklesVFX;
    [SerializeField] private int _maxHits;

    private Level _level;
    private GameSession _gameSession;

    [SerializeField] private int _timesHit; //Serialized for debug
    
    private void Awake()
    {
        _level = FindObjectOfType<Level>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (CompareTag("Breakable"))
        {
            _level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        _timesHit++;
        if (_timesHit >= _maxHits)
        {
            DestroyBlock();
        }
    }
    
    private void DestroyBlock()
    {
        _gameSession.AddToScore();
        AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        _level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(_blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}