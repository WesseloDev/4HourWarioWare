using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool _gameActive = false;
    
    public static bool GameActive => _gameActive;

    private LifeManager _lifeManager;
    private RoundManager _roundManager;
    private UIManager _uiManager;

    void Start()
    {
        _lifeManager = FindObjectOfType<LifeManager>();
        _roundManager = FindObjectOfType<RoundManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }
    
    public void StartGame()
    {
        _lifeManager.Reset();
        _roundManager.Reset();
        _gameActive = true;
    }

    public void EndGame()
    {
        _gameActive = false;
        _uiManager.EndGame();
        Debug.Log("Score: " + RoundManager.RoundCount);
    }
}
