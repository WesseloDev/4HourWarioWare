using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private bool _debug = false;
    [SerializeField] private GameObject[] _debugMinigames;
    
    [Space(20)]
    [SerializeField] private float _timeBetweenRounds;
    
    [SerializeField] private GameObject[] _minigames;
    private static bool _roundActive = false;
    private Round _currentRound;
    private static int _roundCount;

    private float _timeSinceLastRound;

    private static float _speed = 1f;
    private static float _maxSpeed = 0.2f;
    [SerializeField] private float _speedUpRate = 0.9f;
    [SerializeField] private int _speedUpEvery = 4;

    private bool _speedUpThisRound => _roundCount % _speedUpEvery == 0;
    
    public static bool RoundActive => _roundActive;
    public static float RoundSpeed => _speed;
    public static int RoundCount => _roundCount; 
    
    private GameObject[] ArrayToUse => _debug ? _debugMinigames : _minigames;

    private LifeManager _lifeManager;
    private GameManager _gameManager;
    private UIManager _uiManager;

    void Start()
    {
        _lifeManager = FindObjectOfType<LifeManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    void StartRound()
    {
        //Debug.Log("Start round");
        GameObject minigame = Instantiate(ArrayToUse[Random.Range(0, ArrayToUse.Length)]);
        _currentRound = minigame.GetComponent<Round>();
        _currentRound.roundManager = this;
        _currentRound.StartRound();
        
        _roundActive = true;
        _uiManager.HideGame();
    }

    public void EndRound()
    {
        //Debug.Log("Was round won? " + _currentRound.RoundWon);
        if (!_currentRound.RoundWon)
        {
            _lifeManager.TakeLife();
        }
        Destroy(_currentRound.transform.gameObject);
        _currentRound = null;
        
        _timeSinceLastRound = Time.time;
        _roundActive = false;

        if (LifeManager.CurrentLives == 0)
        {
            _gameManager.EndGame();
        }
        else
        {
            _roundCount++;
            if (_speedUpThisRound)
            {
                _speed *= _speedUpRate;
                _speed = Mathf.Clamp(_speed, _maxSpeed, Mathf.Infinity);
                Debug.Log("Speed up! New speed multiplier: " + _speed);
            }
            _uiManager.SetRoundsText(_roundCount);
            _uiManager.ShowGame();
        }
    }
    
    public void Reset()
    {
        _speed = 1f;
        _roundCount = 1;
        _uiManager.SetRoundsText(_roundCount);
        _timeSinceLastRound = Time.time;
    }

    void Update()
    {
        if (!GameManager.GameActive) return;
        
        if (!_roundActive && Time.time > _timeSinceLastRound + (_timeBetweenRounds * _speed))
        {
            StartRound();
        }
    }
}
