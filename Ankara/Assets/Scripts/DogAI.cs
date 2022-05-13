using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogAI : MonoBehaviour
{
    public float range,maxRange;
    public float speed;

    Transform player;

    bool _canFollow;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (CheckIfPlayerInRange())
        {
            DOVirtual.DelayedCall(0.5f, () => { _canFollow = true; });
        }
        if (CheckIfPlayerIsLost())
        {
            _canFollow = false;
        }


    }

    private void FixedUpdate()
    {
        if (_canFollow)
        {
            FollowPlayer();
        }
    }


    bool CheckIfPlayerInRange()
    {
        if (Vector2.Distance(player.position,transform.position) <= range)
        {
            return true;
        }
        return false;
    }
    bool CheckIfPlayerIsLost()
    {
        if (Vector2.Distance(player.position, transform.position) > maxRange)
        {
            return true;
        }
        return false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Player Öldürme
        }
    } //WIP


    void FollowPlayer()
    {
        //Follow 
    } //WIP
}
