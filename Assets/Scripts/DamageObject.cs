using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DamageDestroy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DamageDestroy() {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
