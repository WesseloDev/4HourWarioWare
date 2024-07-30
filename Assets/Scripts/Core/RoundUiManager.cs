using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundUiManager : MonoBehaviour
{
    [SerializeField] private Text _hintText;
    [SerializeField] private Text _timerText;

    private float _hintDisplayTime = 1f;
    
    IEnumerator HintCoroutine()
    {
        yield return new WaitForSeconds(_hintDisplayTime);

        _hintText.text = "";
    }

    public void ShowHint(string hintText)
    {
        _hintText.text = hintText;
        
        StartCoroutine("HintCoroutine");
    }

    public void UpdateTimer(float time, float roundLength)
    {
        int timeInSeconds = Mathf.RoundToInt(roundLength - time);

        _timerText.text = "Time Left: " + timeInSeconds.ToString();
    }
}
