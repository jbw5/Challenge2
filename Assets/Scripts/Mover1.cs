using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover1 : MonoBehaviour
{
    
        Vector2 pointA = new Vector2(7, -2.5f);
        Vector2 pointB = new Vector2(8, -2.5f);
    


        void Update()
        {
            transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
        }
    

}
