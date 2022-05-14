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

    [SerializeField] Animator _animator;
    float playerRotation = 0;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState != GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.ProgressGame();
            }

            return;
        }

        GetInput();
        Move();
        SetAnimatorRotationFloat();
        CheckIfStaminaZero();
    }


    void Move()
    {
        transform.Translate(_movingLine * (Time.deltaTime * (_playerManager.CurrentStamina > 0 ? Speed : Speed / 2f)));
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastInputPos = Input.mousePosition;
            _shouldCheckInput = true;
        }

        if (_shouldCheckInput && Input.GetMouseButton(0))
        {
            
            
            var distanceLine = (Vector2) Input.mousePosition - _lastInputPos;
            if (distanceLine.magnitude == 0) {
                playerRotation = 0;
                return;
            } 
            _lastInputPos = Input.mousePosition;
            var goalVector = distanceLine.normalized * new Vector2(0.6f, 0.3f) *
                             (_playerManager.CurrentStamina > 0 ? InputMultiplier : InputMultiplier / 2f);
            if (goalVector.normalized.x > 0 && goalVector.normalized.y < 0 ||
                goalVector.normalized.x < 0 && goalVector.normalized.y > 0)
            {

                if (goalVector.normalized.x > 0 && goalVector.normalized.y < 0) playerRotation = -1;
                else if (goalVector.normalized.x < 0 && goalVector.normalized.y > 0) playerRotation = 1;

                goalVector = (Vector2) transform.position + goalVector;

                // transform.Translate(translation);
                transform.position = Vector2.Lerp((Vector2) transform.position, goalVector, Time.time);

                
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StaminaCollectible"))
        {
            ParticleManager.Instance.SpawnParticle(ParticleManager.Instance.collectParticle);
            AudioManager.Instance.PlayAudio("collectStamina");
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
            AudioManager.Instance.PlayAudio("meow");
            ParticleManager.Instance.SpawnParticle(ParticleManager.Instance.deathParticle);
            GameManager.Instance.GameOver();
        }
    }

    private void SetAnimatorRotationFloat()
    {
        _animator.SetFloat("Rotation", playerRotation);
        playerRotation = 0;
    }

    private void CheckIfStaminaZero()
    {
        if(_playerManager.CurrentStamina > 0)
        {
            _animator.SetBool("cantRun", false);
        }
        else
        {
            _animator.SetBool("cantRun", true);
        }
    }
}