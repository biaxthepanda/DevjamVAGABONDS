using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Vector2 _movingLine = new Vector2(0.66f, 0.33f).normalized;

    // Input handling
    private bool _shouldCheckInput;
    private Vector2 _lastInputPos;
    public float InputMultiplier;

    [SerializeField] private PlayerManager _playerManager;


    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }


    void Move()
    {
        transform.Translate(_movingLine * (Time.deltaTime * (_playerManager.CurrentStamina > 0 ? Speed : Speed/2f)));
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastInputPos = Input.mousePosition;
            _shouldCheckInput = true;
        }

        if (_shouldCheckInput && Input.GetMouseButton(0))
        {
            var distanceLine = (Vector2)Input.mousePosition - _lastInputPos;
            if (distanceLine.magnitude == 0) return;
            _lastInputPos = Input.mousePosition;
            if (distanceLine.x > 0 && distanceLine.y < 0 || distanceLine.x < 0 && distanceLine.y > 0)
            {
                transform.Translate(distanceLine.normalized * Time.deltaTime * (_playerManager.CurrentStamina > 0 ? InputMultiplier : InputMultiplier / 4f));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StaminaCollectible"))
        {
            _playerManager.CollectStamina(other.GetComponent<CollectibleStamina>().value);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("MaxStaminaCollectible"))
        {
            _playerManager.MaximizeStamina();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("FoodCollectible"))
        {
            _playerManager.CollectFood(other.GetComponent<CollectibleFood>().value);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("DeathTile"))
        {
            //gameover logic through gamemanager
        }
    }
}