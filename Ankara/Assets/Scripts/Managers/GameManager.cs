using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton
    
    private static GameManager _Instance;
    public static GameManager Instance => _Instance;
    
    private Level _currentLevel;

    [SerializeField] private PlayerManager _player;
    public PlayerManager Player => _player;

    [SerializeField] private List<Level> _activeLevels;

    public Action<Level> LevelLoaded;
    
    public UnityEvent GameStateChanged;

    public GameState GameState;

    
    private void Awake()
    {
        _Instance = this;
    }
    
    #endregion



    private void Start()
    {
        Registry.LastLevelIndex--;
        GameState = GameState.MainMenu;
        StartLevel();
    }
    
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
        _player.Restart();
    }

    public void GameOver()
    {
        GameState = GameState.GameOver;
        GameStateChanged.Invoke();
        //Statlar falan çekilsin playerdan onlar yazsın kaç yemek topladın kaç lazımdı vsvs
    }

    public void ProgressGame()
    {
        if (GameState == GameState.MainMenu)
        {
            GameState = GameState.Playing;
            GameStateChanged.Invoke();
        }
        else if (GameState == GameState.Playing)
        {
            NextLevel();
            GameState = GameState.MainMenu;
        }
        else if (GameState == GameState.GameOver)
        {
            Restart();
            GameState = GameState.Playing;
            GameStateChanged.Invoke();
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