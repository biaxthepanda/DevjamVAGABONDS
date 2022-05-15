using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    
    private static UIManager _Instance;
    public static UIManager Instance => _Instance;

    public GameObject MainMenuUI;
    public GameObject PlayingUI;
    public GameObject GameOverUI;

    [SerializeField] private TMP_Text _foodText;
    
    private void Awake()
    {
        _Instance = this;
    }
    
    #endregion

    public void SetUI()
    {
        var state = GameManager.Instance.GameState;
        if (state == GameState.MainMenu)
        {
            MainMenuUI.SetActive(true);
            PlayingUI.SetActive(false);
            GameOverUI.SetActive(false);
        }
        else if (state == GameState.Playing)
        {
            MainMenuUI.SetActive(false);
            PlayingUI.SetActive(true);
            GameOverUI.SetActive(false);
        }
        else if (state == GameState.GameOver)
        {
            MainMenuUI.SetActive(false);
            PlayingUI.SetActive(false);
            GameOverUI.SetActive(true);
        }
    }

    public void SetFoodCount(int totalCount, int maxCount)
    {
        _foodText.text = totalCount + "/" + maxCount;
    }
}
