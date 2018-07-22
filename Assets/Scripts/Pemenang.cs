using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pemenang : MonoBehaviour {
	public GameObject cewek;
	public GameObject cowok;
	// Use this for initialization
	void Start () {
        
       
		if (GameController.pemenang == "cewek") {
			Instantiate (cewek, transform.position, transform.rotation);
            cewek.GetComponent<HealthPointPlayer>().enabled = false;
        } else {
			Instantiate (cowok, transform.position, transform.rotation);
            cowok.GetComponent<HealthPointPlayer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
