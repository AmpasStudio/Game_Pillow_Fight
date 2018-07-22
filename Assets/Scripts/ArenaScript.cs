using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaScript : MonoBehaviour {
    public Sprite notChoosen;
    public Sprite Choosen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (transform.position.x == 0) {
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = Choosen;
        }
        else {
            transform.localScale = new Vector3(0.4f, 0.4f, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = notChoosen;
        }
        
        
        
        
    }
}
