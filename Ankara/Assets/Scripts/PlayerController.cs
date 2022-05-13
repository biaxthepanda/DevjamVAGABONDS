using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    private Vector3 _input;
    public float speed;
    

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }


    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb.MovePosition(transform.position + _input * Time.deltaTime* speed);
    }
    
    private void GetInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0);
    }

}
