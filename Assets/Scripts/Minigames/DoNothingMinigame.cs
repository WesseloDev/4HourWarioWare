using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class DoNothingMinigame : MonoBehaviour
{
    private Round _round;

    private bool _failed = false;
    
    [SerializeField] private Text _text;

    void Start()
    {
        _round = FindObjectOfType<Round>();
    }
    
    void Update()
    {
        if (!RoundManager.RoundActive || _failed) return;

        if (Input.anyKey || Input.GetAxis("Mouse ScrollWheel") != 0f ||
            Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
        {
            _failed = true;
            _round.LoseRound();
            _text.text = ":(";
        }
    }
}
