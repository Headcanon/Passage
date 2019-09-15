using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patada : MonoBehaviour
{
    public void Kill(Transform alvo)
    {
        transform.position = new Vector3(alvo.position.x, alvo.position.y);
    }

}
