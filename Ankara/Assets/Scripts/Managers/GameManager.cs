using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    
    private static GameManager _Instance;
    public static GameManager Instance => _Instance;

    private Level _currentLevel;

    [SerializeField] private PlayerManager _player;

    [SerializeField] private List<Level> _activeLevels;

    public Action<Level> LevelLoaded;
    public Action<GameState> GameStateChanged;

    public GameState GameState;

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        Registry.LastLevelIndex--;
        GameState = GameState.MainMenu;
        StartLevel();
    }

    #endregion
    
    //METHODS HERE:
    public void Restart()
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel.gameObject);
            _currentLevel = null;
            _player.Restart();
            Registry.LastLevelIndex--;
            StartLevel();
        }
    }

    private void StartLevel()
    {
        var level = Instantiate(_activeLevels[Registry.LastLevelIndex]);
        if (!level) return;
        Registry.LastLevelIndex++;
        _currentLevel = level;
        LevelLoaded.Invoke(_currentLevel);
    }

    public void GameOver()
    {
        GameState = GameState.GameOver;
        // GameStateChanged.Invoke(GameState);
        //Game over ekranı gelsin
        //Statlar falan çekilsin playerdan onlar yazsın kaç yemek topladın kaç lazımdı vsvs
    }

    public void ProgressGame()
    {
        if (GameState == GameState.MainMenu)
        {
            GameState = GameState.Playing;
            GameStateChanged.Invoke(GameState);
        }
        else if (GameState == GameState.Playing)
        {
            NextLevel();
        }
        else if (GameState == GameState.GameOver)
        {
            Restart();
            GameState = GameState.Playing;
            // GameStateChanged.Invoke(GameState);
        }
    }

    private void NextLevel()
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel);
            _currentLevel = null;
            StartLevel();
        }
    }
}

public enum GameState
{
    MainMenu,
    Playing,
    GameOver
}