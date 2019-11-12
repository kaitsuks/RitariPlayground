using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmaTatti : MonoBehaviour
{
    //private  Camera camera; // ei tarvita tässä
    float angle; //suuntakulma keskipisteestä
    float x, y, z; //objektin koordinaatit
    //public Transform target; ei käytössä tässä
    Vector3 pos1; //keskipisteen sijainti, liikkuvan objektin sijainti
    Vector3 pos2; //hiiren sijainti
    Vector3 targetDir; //laskennallinen suuntakulma
    Color color; //Debuggausviivan väri
    int n; //tulostuslaskuri
    Vector3 heading; //suunta
    float distance; //etäisyys

    public GameObject ohjus;
    Rigidbody2D rigidBody2D;
    public float speed = 1f;
    Vector2 movement;

    private Touch touch;

    private float width;
    private float height;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }

    // Start is called before the first frame update
    void Start()
    {


        //camera = Camera.main;
        // https://answers.unity.com/questions/697830/how-to-calculate-direction-between-2-objects.html
        //print("print() Toimii...: " + n);

        rigidBody2D = ohjus.GetComponent<Rigidbody2D>();
        pos1 = transform.position;
        //pos1 = new Vector3(1800f, 1000f, 0f);
        pos2 = new Vector3(1800f, 1000f, 0f);

    }

    void OnDrawGizmos()
    {
        // voi kokeilla Gizmo-tulostusta jos haluaa
        // Draw a yellow sphere at the transform's position
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, 1);
        //Gizmos.DrawLine(pos, pos + dir * 10);
        //Gizmos.DrawLine(pos, pos + new Vector3(10, 5, 0));

    }

    void FixedUpdate()
    {
            //if (Input.GetMouseButton(0))
            if (Input.touchCount > 0)
            {
            touch = Input.GetTouch(0);
            //pos1 = Vector3.zero; // Keskipiste - voi olla muukin kuin origo, voi asettaa Startissa

            pos2 = Input.mousePosition; //hiiren sijainti
            //pos2 = Camera.main.ScreenToWorldPoint(touch.position);
            pos2 = touch.position;
            pos2.x = (pos2.x - width) / width;
            pos2.y = (pos2.y - height) / height;
            //pos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);



            pos1.z = 0; //z-komponenttia ei tarvita
            pos2.z = 0;
            x = ohjus.transform.position.x; //objektin x-koordinaatti tarvitaan, jotta saadaan selville ollaanko "idässä vai lännessä"
            heading = pos2 - pos1; //lasketaan suunta
            distance = heading.magnitude; //lasketaan etäisyys
            targetDir = heading.normalized; //lasketaan suunta, muutetaan vektorin pituudeksi 1.
            angle = Vector3.SignedAngle(targetDir, transform.up, Vector3.right); //lasketaan suuntakulma
            if (x < 0) { angle = 180f + (180f - angle); } //korjataan suuntakulma, jos ollaan "lännessä"
            color = Color.red; //whatever, voi asettaa Startissakin
            Debug.DrawLine(Vector3.zero, targetDir * 10, color); // piirretään debuggausviiva objektiin



            // Apply the force to the Rigidbody2d
            rigidBody2D.AddForce(targetDir * speed * distance * 1f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        n++; // tulostuslaskuri, ettei tulosteta jatkuvasti
        if (n > 10)
        {
            n = 0;
           // print("angle: " + angle + " distance " + distance); // tulostetaan kulma 0 - 360 astetta origosta liikkuvaan objektiin sekä etäisyys
        }
    }
}
