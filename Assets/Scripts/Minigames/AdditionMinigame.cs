using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionMinigame : MonoBehaviour
{
    private Round _round;

    private int _answer;
    private int _numberOne, _numberTwo;
    private bool _canAnswer = true;

    [SerializeField] private Text _questionText;
    [SerializeField] private Text _answerText;
    
    void Start()
    {
        _round = FindObjectOfType<Round>();
        
        _numberOne = Random.Range(0, 9);
        _numberTwo = Random.Range(0, 9 - _numberOne);
        _answer = _numberOne + _numberTwo;

        _questionText.text = Random.Range(0, 1) == 1
            ? _numberOne + " + " + _numberTwo + " = ?"
            : _numberTwo + " + " + _numberOne + " = ?";
    }

    void Update()
    {
        if (!RoundManager.RoundActive || !_canAnswer) return;
        
        // bad but im on a time limit
        for (int i = 0; i < 10; i++)
        {

            if (!Input.GetKeyDown(i.ToString())) continue;

            Debug.Log("Key down: " + i);
            
            _answerText.text = i.ToString();
            
            if (i == _answer)
            {
                _answerText.text = _answerText.text + "\n:)";
                _round.WinRound();
            }
            else
            {
                _answerText.text = _answerText.text + "\n:(";
                _round.LoseRound();
            }
            
            _canAnswer = false;
            return;
        }
    }
}
