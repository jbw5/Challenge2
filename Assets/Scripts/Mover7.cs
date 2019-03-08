using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover7 : MonoBehaviour
{

    Vector2 pointA = new Vector2(62, -2.5f);
    Vector2 pointB = new Vector2(63, -2.5f);



    void Update()
    {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }


}