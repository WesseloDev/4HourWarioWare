using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButtonMinigame : MonoBehaviour
{
    private Round _round;

    private int _pressedTimes = 0;
    [SerializeField] private float xOffsetMax, yOffsetMax;

    [SerializeField] private Button _button;
    
    void Start()
    {
        _round = FindObjectOfType<Round>();
        
        RandomizeButtonPosition();
    }

    public void ButtonClicked()
    {
        _pressedTimes++;

        if (_pressedTimes == 5)
        {
            _round.WinRound();
            _button.gameObject.SetActive(false);
        }
        else
        {
            RandomizeButtonPosition();
        }
    }

    void RandomizeButtonPosition()
    {
        _button.GetComponent<RectTransform>().localPosition = new Vector3(
            Random.Range(-xOffsetMax, xOffsetMax), 
            Random.Range(-yOffsetMax, yOffsetMax));
        
        //Debug.Log(_button.GetComponent<RectTransform>().position);
    }
}
