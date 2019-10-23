using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KforControl : MonoBehaviour {

    Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        if (Input.GetKeyDown("a"))
        //välilyönti - tai muu näppäin
        {
            animator.SetTrigger("StandLeft");
        }

        if (Input.GetKeyDown("d"))
        //välilyönti - tai muu näppäin
        {
            animator.SetTrigger("StandRight");
        }
        if (Input.GetKeyDown("right"))
        //välilyönti - tai muu näppäin
        {
            animator.SetTrigger("WalkRight");
        }
        if (Input.GetKeyDown("left"))
        //välilyönti - tai muu näppäin
        {
            animator.SetTrigger("WalkLeft");
        }
        if (Input.GetKeyDown("l"))
        //välilyönti - tai muu näppäin
        {
            animator.SetTrigger("AttackRight");
        }
        if (Input.GetKeyDown("k"))
        //välilyönti - tai muu näppäin
        {
            animator.SetTrigger("AttackLeft");
        }
    }
}
