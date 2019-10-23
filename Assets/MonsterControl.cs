using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/MonsterControl")]
[RequireComponent(typeof(Rigidbody2D))]
public class MonsterControl : Physics2DObject
{
    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 0f;
    public float deltaspeed = 0.05f;
    public float maxspeed = 1f;
    public float speedCoefficient = 3; //multiplier

    public Enums.MovementType movementType = Enums.MovementType.AllDirections;

    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that will face the player
    public Enums.Directions lookAxis = Enums.Directions.Up;

    private Vector2 movement, cachedDirection;
    private Vector3 velo;
    private float moveHorizontal;
    private float moveVertical;
    bool directionRight = true;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update gets called every frame
    void Update()
    {
        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }

        //zero-out the axes that are not needed, if the movement is constrained
        //switch (movementType)
        //{
        //    case Enums.MovementType.OnlyHorizontal:
        //        moveVertical = 0f;
        //        break;
        //    case Enums.MovementType.OnlyVertical:
        //        moveHorizontal = 0f;
        //        break;
        //}

        movement = new Vector2(moveHorizontal, moveVertical);


        //rotate the GameObject towards the direction of movement
        //the axis to look can be decided with the "axis" variable
        //if (orientToDirection)
        //{
        //    if (movement.sqrMagnitude >= 0.01f)
        //    {
        //        cachedDirection = movement;
        //    }
        //    Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
        //}

        //if(directionRight)
        //    movement = new Vector2(0.1f, 0f);
        //else
        //    movement = new Vector2(-0.1f, 0f);
        //if(speed == 0)
        //    movement = new Vector2(0f, 0f);

    }



    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        velo = rigidbody2D.velocity;
        speed -= deltaspeed/3;
        if (speed < 0.0f) speed = 0.0f;
        // Apply the force to the Rigidbody2d
        rigidbody2D.AddForce(movement * Mathf.Abs(speed) * speedCoefficient);
    }

    private void LateUpdate()
    {
        //Voidaan tarkistaa muuttujan arvo näinkin
        //Debug.Log("MoveHorizontal = " + moveHorizontal);
        //if (Input.GetKeyDown("a"))
            //if (speed == 0 && !directionRight)
            if (velo.x < 0.2f && velo.y < 0.2f && !directionRight)
            //
            {
            animator.SetTrigger("StandLeft");
        }

        //if (Input.GetKeyDown("d"))
        //
        //if(speed==0 && directionRight)
            if (velo.x < 0.2f && velo.y < 0.2f && directionRight)
            {
            animator.SetTrigger("StandRight");
        }
        //if (Input.GetKeyDown("right"))
            if (Input.GetKey("right"))
            //
            {
            directionRight = true;
            animator.SetTrigger("WalkRight");
            speed += 0.1f;
            //speed += 1f;
            if (speed > maxspeed) speed = maxspeed;
        }
        //if (Input.GetKeyDown("left"))
            if (Input.GetKey("left"))
            //
            {
            directionRight = false;
            animator.SetTrigger("WalkLeft");
            speed += 0.1f;
            //speed += 1f;
            if (speed > maxspeed) speed = maxspeed;
        }
        if (Input.GetKey("up"))
        //
        {
            //directionRight = false;
            //animator.SetTrigger("WalkLeft");
            speed += 0.1f;
            //speed += 1f;
            if (speed > maxspeed) speed = maxspeed;
        }
        if (Input.GetKey("down"))
        //
        {
            //directionRight = false;
            //animator.SetTrigger("WalkLeft");
            speed += 0.1f;
            //speed += 1f;
            if (speed > maxspeed) speed = maxspeed;
        }
        if (Input.GetKeyDown("l"))
        //
        {
            animator.SetTrigger("AttackRight");
        }
        if (Input.GetKeyDown("k"))
        //
        {
            animator.SetTrigger("AttackLeft");
        }
    }

    public void SlowDown(float slow)
    {
        //Debug.Log("Puussa ollaan, jarrutetaan");
        //speed -= slow;
        deltaspeed = 0.01f;
        speed = 0.0f;
        speedCoefficient = 1f;
        //rigidbody2D.velocity = new Vector3(0.0f, -0.1f, 0);
    }
    public void RunFaster(float fast)
    {
        //Debug.Log("Ja taas mennään!");
        speed = 0.5f;
        deltaspeed = 0.05f;
        //maxspeed = 1f;
        speedCoefficient = 3;
    }
}
