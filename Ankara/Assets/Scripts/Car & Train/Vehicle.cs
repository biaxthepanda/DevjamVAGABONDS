using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    public bool leftToRight;
    public float speed;
    Vector2 direction;
    public bool canMove;



    private void Start()
    {
        canMove = true;
        DetermineDirection();
        
    }
    private void Update()
    {
        if (canMove) Move();
    }

    void DetermineDirection()
    {
        direction = leftToRight ? new Vector2(0.6f, -0.3f).normalized : new Vector2(-0.6f,0.3f).normalized;
    }
    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
