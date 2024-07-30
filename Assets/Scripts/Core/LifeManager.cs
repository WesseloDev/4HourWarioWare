using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private int _maxLives = 4;
    private static int _currentLives;
    
    private UIManager _uiManager;

    public static int CurrentLives => _currentLives;

    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }
    
    public void AddLife()
    {
        _currentLives++;
        _currentLives = Math.Clamp(_currentLives, 0, _maxLives);
        _uiManager.SetLivesText(_currentLives);
    }

    public void TakeLife()
    {
        _currentLives--;
        _uiManager.SetLivesText(_currentLives);
    }
    
    public void Reset()
    {
        _currentLives = _maxLives;
        _uiManager.SetLivesText(_currentLives);
    }
}
