using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    private Rigidbody2D _rgbd;
    private Vector2 _direction;
    public float speed = 30f;
    public KeyCode up;
    public KeyCode down;


    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            _direction = Vector2.up;

        } else if (Input.GetKey(down) )
        {
            _direction = Vector2.down;

        } else 
        { 
            _direction = Vector2.zero; 
        }
    }

    void FixedUpdate()
    {
        if (_direction == Vector2.zero)
            return;
        _rgbd.AddForce(_direction * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name + ("touch"));
    }
}
