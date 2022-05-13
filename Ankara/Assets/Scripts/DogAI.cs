using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogAI : MonoBehaviour
{
    public float range,maxRange;
    public float speed,horizontalSpeed;

    Transform playerTransform;
    Vector2 _movingLine = new Vector2(0.66f, 0.33f).normalized;

    bool _canFollow;
    LayerMask playerLayer;

    Vector2 playerLastPos;

   

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    private void Update()
    {
        if (SendRay())
        {
            DOVirtual.DelayedCall(0.25f, () =>
            {
                _canFollow = true;
            });
        }


    }

    private void FixedUpdate()
    {
        if (_canFollow)
        {
            FollowPlayer();
        }
    }


    /* bool CheckIfPlayerInRange()
    {
        if (Vector2.Distance(playerTransform.position,transform.position) <= range)
        {
            return true;
        }
        return false;
    } */
    /* bool CheckIfPlayerIsLost()
    {
        if (Vector2.Distance(playerTransform.position, transform.position) > maxRange)
        {
            return true;
        }
        return false;
    } */
    bool SendRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0.3f, -0.6f),range,playerLayer);
        if (hit)
        {
            return true;
            Vector2 playerLastPos = playerTransform.position;
        }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Player Öldürme 
        }
    } //WIP


    void FollowPlayer()
    {

        Vector2 horizontalLine = new Vector2(-_movingLine.y, _movingLine.x);
        if(playerTransform.position.x < playerLastPos.x)
        {
            transform.Translate(horizontalLine*horizontalSpeed*Time.deltaTime);
        }
        else if (playerTransform.position.z > playerLastPos.x)
        {
            transform.Translate(-horizontalLine*horizontalSpeed*Time.deltaTime);
        }
        

        transform.Translate(_movingLine*speed * Time.deltaTime);
        playerLastPos = playerTransform.position;
    } //WIP
}
