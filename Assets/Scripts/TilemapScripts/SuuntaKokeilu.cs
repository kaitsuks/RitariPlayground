using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuuntaKokeilu : MonoBehaviour
{
    //private  Camera camera; // ei tarvita tässä
    float angle; //suuntakulma keskipisteestä
    float x, y, z; //objektin koordinaatit
    //public Transform target; ei käytössä tässä
    Vector3 pos1, pos2; //keskipisteen sijainti, liikkuvan objektin sijainti
    Vector3 targetDir; //laskennallinen suuntakulma
    Color color; //Debuggausviivan väri
    int n; //tulostuslaskuri
    Vector3 heading; //suunta
    float distance; //etäisyys

    // Start is called before the first frame update
    void Start()
    {

        
        //camera = Camera.main;
        // https://answers.unity.com/questions/697830/how-to-calculate-direction-between-2-objects.html
        //print("print() Toimii...: " + n);
        
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
        
        pos1 = Vector3.zero; // Keskipiste - voi olla muukin kuin origo, voi asettaa Startissa
        pos2 = transform.position; //liikuteltavan objektin, johon tämä skripti liittyy, sijainti
        pos1.z = 0; //z-komponenttia ei tarvita
        pos2.z = 0;
        x = this.transform.position.x; //objektin x-koordinaatti tarvitaan, jotta saadaan selville ollaanko "idässä vai lännessä"
        heading = pos2 - pos1; //lasketaan suunta
        distance = heading.magnitude; //lasketaan etäisyys
        targetDir = (pos2 - pos1).normalized; //lasketaan suunta, muutetaan vektorin pituudeksi 1.
        angle = Vector3.SignedAngle(targetDir, transform.up, Vector3.right); //lasketaan suuntakulma
        if (x < 0) { angle = 180f + (180f - angle); } //korjataan suuntakulma, jos ollaan "lännessä"
        color = Color.red; //whatever, voi asettaa Startissakin
        Debug.DrawLine(Vector3.zero, targetDir * 10, color); // piirretään debuggausviiva objektiin
    }

    // Update is called once per frame
    void Update()
    {
        n++; // tulostuslaskuri, ettei tulosteta jatkuvasti
        if (n > 10)
        {
            n = 0;
            print("angle: " + angle + " distance " + distance); // tulostetaan kulma 0 - 360 astetta origosta liikkuvaan objektiin sekä etäisyys
        }
    }
}
