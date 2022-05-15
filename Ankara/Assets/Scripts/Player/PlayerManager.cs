using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int MaxStamina;
    private float _currentStamina;
    public float CurrentStamina => _currentStamina;
    public float _staminaDecreaseRate;

    private int _requiredFood;
    private int _foodAmount;
    public int FoodAmount => _foodAmount;

    private void OnEnable()
    {
        GameManager.Instance.LevelLoaded += OnLevelLoaded;
    }

    private void OnDisable()
    {
        GameManager.Instance.LevelLoaded -= OnLevelLoaded;
    }

    private void Start()
    {
        _currentStamina = MaxStamina;
        _foodAmount = 0;
    }

    private void Update()
    {
        if (_currentStamina > 0 && GameManager.Instance.GameState == GameState.Playing)
        {
            _currentStamina -= _staminaDecreaseRate * Time.deltaTime;
            UIManager.Instance.UpdateStaminaBar(_currentStamina/MaxStamina);
        }
    }

    public void CollectStamina(float collectedStaminaValue)
    {
        _currentStamina = Mathf.Clamp(_currentStamina+collectedStaminaValue, 0, MaxStamina);
        UIManager.Instance.UpdateStaminaBar(_currentStamina / MaxStamina);
    }

    public void MaximizeStamina()
    {
        _currentStamina = MaxStamina;
    }

    public void CollectFood(int collectedFoodValue)
    {
        _foodAmount += collectedFoodValue;
        UIManager.Instance.SetFoodCount(_foodAmount, _requiredFood);
    }

    public void Restart()
    {
        //set position
        //set stamina
        //set food
        //set whatever needed here
        transform.position = Vector3.zero;
        _currentStamina = MaxStamina;
        UIManager.Instance.SetFoodCount(0, _requiredFood);
        Debug.Log("Restart for player done.");
    }

    private void OnLevelLoaded(Level level)
    {
        _requiredFood = level.RequiredFood;
        _foodAmount = 0;
        AudioManager.Instance.ChangeMusic(Registry.LastLevelIndex-1);
    }
}
