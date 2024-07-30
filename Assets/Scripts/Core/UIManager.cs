using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameGui;
    [SerializeField] private GameObject _loseGui;
    
    [SerializeField] private Text _livesText;
    [SerializeField] private Text _roundsText;

    public void ShowGame()
    {
        _gameGui.SetActive(true);
    }
    
    public void HideGame()
    {
        _gameGui.SetActive(false);
    }

    public void EndGame()
    {
        _gameGui.SetActive(false);
        _loseGui.SetActive(true);
    }

    public void SetLivesText(int amount)
    {
        _livesText.text = "Lives: " + amount.ToString();
    }

    public void SetRoundsText(int amount)
    {
        _roundsText.text = "Round: " + amount.ToString();
    }
}
