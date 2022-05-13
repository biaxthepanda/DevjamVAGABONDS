using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _input;
    public float speed;
    

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }
    

    void Move()
    {
        transform.Translate( _input * (Time.deltaTime * speed));
        // _rb.MovePosition(transform.position + _input * Time.deltaTime* speed);
    }
    
    private void GetInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0).normalized;
    }

}
