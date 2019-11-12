using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccInput3D : MonoBehaviour {

    Vector3 baseAcceleration;
    // Use this for initialization
    void Start () {
       
        baseAcceleration = Input.acceleration;
    }

    // Update is called once per frame
    void Update () {
        
          //  transform.Translate(Input.acceleration.x/10f, 0, - 1f + -Input.acceleration.z/10f);
        //Debug.Log("Z arvo " + -Input.acceleration.z / 10f);
    }

    void FixedUpdate()
    {

        float xi = Input.acceleration.x - baseAcceleration.x;
        float yi = Input.acceleration.y - baseAcceleration.y;
        float zi = Input.acceleration.z - baseAcceleration.z;
        transform.Translate(xi / 10f, 0, -zi / 10f);

        //...
    }
}
