using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAwan : MonoBehaviour {
    public float speed;
    
    Vector2 gerakan;
    Transform gerak;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        float move = (speed * Time.deltaTime) + transform.position.x;
        transform.position = new Vector3(move, transform.position.y, 0);
        if (transform.position.x > 25.05f) {
            transform.position = new Vector3(-25.05f, transform.position.y, 0);
        }
	}
   
}
