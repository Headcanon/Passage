using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float slowVel;

    float vel;

    Transform alvo;
    RatMovement alvoScript;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        alvoScript = alvo.GetComponent<RatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, alvo.position) > 12)
        {
            vel = alvoScript.vel;
        }
        else
        {
            vel = slowVel;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(0, vel) * Time.deltaTime);
    }
}
