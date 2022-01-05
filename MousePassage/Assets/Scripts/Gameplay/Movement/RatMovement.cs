using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RatMovement : MonoBehaviour
{
    public float vel;
    public float squishyVel;
    public float moveVel;

    private bool squishy = false;
    private Rigidbody2D rb;

    private Menu menu;
    private ScoreManager sm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        menu = GameObject.FindGameObjectWithTag("GameController").GetComponent<Menu>();
        sm = GameObject.Find("SM").GetComponent<ScoreManager>();
        sm.Resetar();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetButtonDown("Fire1") && !squishy)
        {
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y * 1.5f);
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
        if (!squishy)
        {
            rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal") * moveVel, vel) * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal") * moveVel, squishyVel) * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        if (menu == null)
            return;

        menu.MenuUp();
        menu.restart = true;
    }
}
