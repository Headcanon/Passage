using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float slowVel;
    public float distancia = 8;
    float vel;

    Transform alvo;
    RatMovement alvoScript;

    public Patada patada;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        alvoScript = alvo.GetComponent<RatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alvo != null)
        {
            if (Vector3.Distance(transform.position, alvo.position) > distancia)
            {
                vel = alvoScript.vel;
            }
            else
            {
                vel = slowVel;
            }
        }
    }

    private void FixedUpdate()
    {
        if (alvo != null)
        {
            transform.Translate(new Vector2(0, vel) * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        patada.Kill(alvo);
        Destroy(alvo.gameObject);
    }
}
