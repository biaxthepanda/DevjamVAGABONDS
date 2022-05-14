using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogAI : MonoBehaviour
{
    public float range, maxRange;
    public float speed, horizontalSpeed;

    Vector2 _movingLine = new Vector2(0.66f, 0.33f).normalized;

    bool _canFollow;
    [SerializeField] private LayerMask playerLayer;

    Vector2 playerLastPos;

    [SerializeField] private Transform playerTransform;
    private bool _notFollowing;


    private void Start()
    {
        _notFollowing = true;
    }

    private void Update()
    {
        if (_notFollowing && SendRay())
        {
            DOVirtual.DelayedCall(0.25f, () => { _canFollow = true; });
        }

        if (_canFollow)
        {
            FollowPlayer();
        }
    }

    bool SendRay()
    {
        RaycastHit2D hit =
            Physics2D.Raycast(transform.position, new Vector2(0.66f, -0.33f).normalized, range, playerLayer);
        Debug.DrawRay(transform.position, new Vector2(0.66f, -0.33f).normalized * range, Color.red);
        if (hit)
        {
            playerLastPos = playerTransform.position;
            _notFollowing = false;
            return true;
        }

        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //gg
        }
    } //WIP


    void FollowPlayer()
    {
        // transform.Translate(_movingLine * speed * Time.deltaTime);
        playerLastPos = playerTransform.position;

        transform.position = Vector2.MoveTowards(transform.position, playerLastPos, speed * Time.deltaTime);
    } //WIP
}