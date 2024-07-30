using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField] private bool _roundWon;
    [SerializeField] private float _roundLength;
    [SerializeField] private string _roundHint;

    public RoundManager roundManager;
    private float _roundStartTime;

    private RoundUiManager _roundUiManager;
    
    public bool RoundWon => _roundWon;

    public void WinRound()
    {
        _roundWon = true;
    }

    public void LoseRound()
    {
        _roundWon = false;
    }

    public void StartRound()
    {
        _roundStartTime = Time.time;
        
        _roundUiManager = GetComponentInChildren<RoundUiManager>();
        _roundUiManager.ShowHint(_roundHint);
    }
    
    void Update()
    {
        if (!RoundManager.RoundActive) return;
        
        _roundUiManager.UpdateTimer(Time.time - _roundStartTime, _roundLength * RoundManager.RoundSpeed);
        
        if (Time.time > _roundStartTime + (_roundLength * RoundManager.RoundSpeed))
        {
            roundManager.EndRound();
        }
    }
}
