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

    private int _foodAmount;
    public int FoodAmount => _foodAmount;

    private void Start()
    {
        _currentStamina = MaxStamina;
    }

    private void Update()
    {
        if (_currentStamina > 0)
        {
            _currentStamina -= _staminaDecreaseRate * Time.deltaTime;
        }
    }

    public void CollectStamina(float collectedStaminaValue)
    {
        _currentStamina = Mathf.Clamp(_currentStamina+collectedStaminaValue, 0, MaxStamina);
    }

    public void MaximizeStamina()
    {
        _currentStamina = MaxStamina;
    }

    public void CollectFood(float collectedFoodValue)
    {
        _currentStamina += collectedFoodValue;
    }

    public void Restart()
    {
        //set position
        //set stamina
        //set food
        //set whatever needed here
        Debug.Log("Restart for player done.");
    }
}
