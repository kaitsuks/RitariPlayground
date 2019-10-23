using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePC : MonoBehaviour {
    GameObject proffa;
    GameObject kim;
    GameObject ritari;
    Move proffaMove;
    Move kimMove;
    Move ritariMove;

    // Use this for initialization
    void Start () {
        proffa = GameObject.Find("ProfToro");
        kim = GameObject.Find("KKollektor");
        ritari = GameObject.Find("SirLancif");
        proffaMove  = proffa.GetComponent<Move>();
        kimMove     = kim.GetComponent<Move>();
        ritariMove  = ritari.GetComponent<Move>();

    }
    // Update is called once per frame
    void Update () {
		
	}

  public  void ChangeProffa()
    {
        //proffaMove.
        //kimMove
        //ritariMove
        proffa.SetActive(true);
        kim.SetActive(false);
        ritari.SetActive(false);


    }

 public   void ChangeKim()
    {
        //proffaMove
        //kimMove
        //ritariMove
        proffa.SetActive(false);
        kim.SetActive(true);
        ritari.SetActive(false);

    }

  public  void ChangeRitari()
    {
        //proffaMove
        //kimMove
        //ritariMove
        proffa.SetActive(false);
        kim.SetActive(false);
        ritari.SetActive(true);

    }
}
