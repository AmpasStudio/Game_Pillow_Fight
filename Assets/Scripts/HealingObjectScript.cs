using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObjectScript : MonoBehaviour {
    Vector3 pos;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)){
            pos.x = transform.position.x;
            pos.y = transform.position.y + 0.1f;
            rb.AddForce(pos);
        }
       
	}
}
