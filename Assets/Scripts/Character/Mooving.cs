using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mooving : MonoBehaviour
{
    public float speed = 14;
    public int directionInput;
    private new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");

        rigidbody2D.velocity = new Vector2(directionInput * speed * Time.deltaTime, rigidbody2D.velocity.y);
        
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;
    }
}
