﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowCursor : MonoBehaviour
{
	public float speed = 2f;

	private Vector3 currentTarget; //the mouse position
	private Vector3 initialPosition;
	public bool targetReached = true;
    public bool stopped = false;
	private float progressToTarget = 0f;
	private float distance;
	private float acceleration;
	private float accelerationDistance = 3f;

	public Rigidbody2D rb2D;
	private Vector3 newPosition;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

    public void Stop()
    {
       
        stopped = true;
        //UnityEngine.Debug.Log("STOPPED!");
    }

    public void Nostop()
    {
        
        stopped = false;
        //UnityEngine.Debug.Log("Going again...");
    }

    private void Update ()
	{
		if(Input.GetMouseButtonDown(0) && !stopped)
		{
			currentTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition); //mouse position is taken only on left click
			currentTarget.z = 0;

			initialPosition = transform.position;
			distance = Vector3.Distance(transform.position, currentTarget);

			//reset some variables
			progressToTarget = 0f;
			acceleration = .1f;
			targetReached = false;
		}


		//the movement routine
		if(!targetReached)
		{
			if(progressToTarget <= accelerationDistance / distance)
			{
				//accelerate
				acceleration += Time.deltaTime * 2f;
				acceleration = Mathf.Min(acceleration, 1f);
			}
			else if(progressToTarget < 1f - accelerationDistance / distance)
			{
				//constant speed
				acceleration = 1f;
			}
			else
			{
				//decelerate
				acceleration -= Time.deltaTime * 2f;
				acceleration = Mathf.Max(acceleration, .1f);
			}

			//calculate the progress to target
			progressToTarget += Time.deltaTime * speed * acceleration / distance * 10f;

			if(progressToTarget <= 1f)
			{
				//cache the movement
				newPosition = Vector3.Lerp(initialPosition, currentTarget, progressToTarget);
			}
			else
			{
				//stop
				targetReached = true;
			}
		}
	}


	private void FixedUpdate()
	{
		if(!targetReached && !stopped)
		{
			rb2D.MovePosition(newPosition);
		}
	}
}