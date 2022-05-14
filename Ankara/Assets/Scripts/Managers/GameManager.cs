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

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        Registry.LastLevelIndex--;
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
    }
}
