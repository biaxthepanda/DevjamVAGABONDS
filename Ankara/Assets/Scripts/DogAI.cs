using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogAI : MonoBehaviour
{
    public float range,maxRange;
    public float speed;

    Transform player;
    Vector2 _movingLine = new Vector2(0.66f, 0.33f).normalized;

    bool _canFollow;

    LayerMask playerLayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        if (Vector2.Distance(player.position,transform.position) <= range)
        {
            return true;
        }
        return false;
    } */
    /* bool CheckIfPlayerIsLost()
    {
        if (Vector2.Distance(player.position, transform.position) > maxRange)
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
        transform.Translate(_movingLine*speed * Time.deltaTime);
    } //WIP
}
