using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    public float vel;
    public float moveVel;

    bool squishy = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetButtonDown("Fire1") && !squishy)
        {
            transform.localScale = new Vector3(transform.localScale.x/2, transform.localScale.y * 1.5f);
            squishy = true;
        }
        else if (Input.GetButtonDown("Fire1") && squishy)
        {
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y / 1.5f);
            squishy = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal") * moveVel, vel) * Time.deltaTime);
    }
}
