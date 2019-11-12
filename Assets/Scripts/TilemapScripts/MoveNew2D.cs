using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Move With Buttons 2D")]
//[RequireComponent(typeof(Rigidbody2D))]
public class MoveNew2D : Physics2DObject
{
	[Header("Input keys")]
	public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

	[Header("Movement")]
	[Tooltip("Speed of movement")]
	public float speed = 5f;
	public Enums.MovementType movementType = Enums.MovementType.AllDirections;

	[Header("Orientation")]
	public bool orientToDirection = false;
	// The direction that will face the player
	public Enums.Directions lookAxis = Enums.Directions.Up;

	private Vector2 movement, cachedDirection;
	private float moveHorizontal;
	private float moveVertical;

    [Header("Movable Object")]
    public GameObject go;

    private Vector3 finalMovement;
    private Vector3 nullMovement = new Vector3(0f, 0f, 0f);
    private float move = 10f;

    [Header("Buttons")]
    public GameObject buttonNorth;
    public GameObject buttonEast;
    public GameObject buttonSouth;
    public GameObject buttonWest;

    private MyButton bNorth;
    private MyButton bEast;
    private MyButton bSouth;
    private MyButton bWest;

    private void Start()
    {

        bNorth = buttonNorth.GetComponent<MyButton>();
        //Debug.Log("Nappula " + buttonNorth + " haettu!");
        bSouth = buttonSouth.GetComponent<MyButton>();
        bWest = buttonWest.GetComponent<MyButton>();
        bEast = buttonEast.GetComponent<MyButton>();
    }

    // Update gets called every frame
    void Update ()
	{
        if (bNorth.buttonPressed) MoveAway();
        if (bSouth.buttonPressed) MoveNearer();
        if (bWest.buttonPressed) MoveLeft();
        if (bEast.buttonPressed) MoveRight();

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
		switch(movementType)
		{
			case Enums.MovementType.OnlyHorizontal:
				moveVertical = 0f;
				break;
			case Enums.MovementType.OnlyVertical:
				moveHorizontal = 0f;
				break;
		}
			
		movement = new Vector2(moveHorizontal, moveVertical);


		//rotate the gameObject towards the direction of movement
		//the axis to look can be decided with the "axis" variable
		if(orientToDirection)
		{
			if(movement.sqrMagnitude >= 0.01f)
			{
				cachedDirection = movement;
			}
			Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
		}
	}



	// FixedUpdate is called every frame when the physics are calculated
	//void FixedUpdate ()
	//{
	//	// Apply the force to the Rigidbody2d
	//	GetComponent<Rigidbody2D>().AddForce(movement * speed * 10f);
	//}

    public void MoveAway()
    {
        finalMovement = nullMovement;
        Vector2 movement = new Vector2(0f, move);
        //Debug.Log("Move Away called " + movement);
        finalMovement = movement;
        // Apply the force to the Rigidbody
        go.GetComponent<Rigidbody2D>().AddForce(finalMovement * speed * 20f);
    }

    public void MoveNearer()
    {
        finalMovement = nullMovement;
        Vector2 movement = new Vector2(0f, -move);
        //Debug.Log("Move Nearer called " + movement);
        finalMovement = movement;
        // Apply the force to the Rigidbody
        go.GetComponent<Rigidbody2D>().AddForce(finalMovement * speed * 20f);
    }

    public void MoveLeft()
    {
        finalMovement = nullMovement;
        Vector3 movement = new Vector3(-move, 0f, 0f);
        //Debug.Log("Move Left called " + movement);
        finalMovement = movement;
        // Apply the force to the Rigidbody
        go.GetComponent<Rigidbody2D>().AddForce(finalMovement * speed * 20f);
    }

    public void MoveRight()
    {
        finalMovement = nullMovement;
        Vector3 movement = new Vector3(move, 0f, 0f);
        //Debug.Log("Move Right called " + movement);
        finalMovement = movement;
        // Apply the force to the Rigidbody
        go.GetComponent<Rigidbody2D>().AddForce(finalMovement * speed * 20f);
    }



    // FixedUpdate is called every frame when the physics are calculated
    //void FixedUpdate()
    //{
    //    // Apply the force to the Rigidbody
    //    rigidbody.AddForce(movement * speed * 10f);
    //}
}