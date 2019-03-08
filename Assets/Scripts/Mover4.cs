using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover4 : MonoBehaviour
{

    Vector2 pointA = new Vector2(71.5f, -1.5f);
    Vector2 pointB = new Vector2(72, -1.5f);



    void Update()
    {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }


}