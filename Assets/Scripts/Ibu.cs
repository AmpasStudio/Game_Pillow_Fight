using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ibu : MonoBehaviour {
	float Timer;
	// Use this for initialization
	void Start () {
		Timer = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Timer -= Time.deltaTime;
		if (Timer < 1) {
			Destroy (gameObject);
		}
	}

}
