using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    Vector2 pointA = new Vector2(30, -2.5f);
    Vector2 pointB = new Vector2(31, -2.5f);



    void Update()
    {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}