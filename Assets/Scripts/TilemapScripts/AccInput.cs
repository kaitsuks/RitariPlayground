using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
            transform.Translate(Input.acceleration.x/10f, -Input.acceleration.y/10f, 0);
        
    }
}
