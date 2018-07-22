using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoverBantal : MonoBehaviour {
	//public static int angin;
	public AudioClip lemparDekat,lemparJauh;
	private AudioSource myAudioSource;
	public float power;
	public int Direction;
	public GameObject Pembatas,cewek,cowok;
	Rigidbody2D rb;
	float vX,vY;
	// Use this for initialization
	public void Start () {
		myAudioSource = GetComponent<AudioSource> ();
		Projectile ();
	}
	void Update(){
        //penggunaan if dibawah ini untuk mengecek apakah posisi bantal sudah keluar dari arena atau belum, 
        //jika sudah keluar arena maka bantal akan di destroy dari scene
		if (transform.position.y < Pembatas.transform.position.y || transform.position.x>10||transform.position.x<-10) {
			Destroy (gameObject);
            GameController.adaBantal = false;
            cowok.GetComponent<PoisonScript>().addedPoison = false;
            cewek.GetComponent<PoisonScript>().addedPoison = false;

        }

		transform.Rotate (0,0,-150*Mathf.Deg2Rad*Direction);
	}
    //method dibawah ini digunakan untuk membuat bantal bergerak parabola
	public void Projectile(){
		rb = GetComponent<Rigidbody2D> ();
		vX = (power * Mathf.Cos (53 * Mathf.Deg2Rad)) * Direction+GameController.angin;
		vY = power * Mathf.Sin (53 * Mathf.Deg2Rad);
		rb.velocity = new Vector2 (vX, vY);
        if (SkillScript.twice == false) {
            GameController.aturAngin();
        }
		Debug.Log (vX.ToString ());
		if (Mathf.Abs(vX) < 12.0f) {
			myAudioSource.clip = lemparDekat;
		} else {
			myAudioSource.clip = lemparJauh;
		}
        float hitung = Mathf.Cos(53 * Mathf.Deg2Rad);
        Debug.Log(hitung.ToString());
		myAudioSource.Play ();
    }
		
}
