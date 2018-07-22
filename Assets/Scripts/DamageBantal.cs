using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBantal : MonoBehaviour {
    public GameObject damage;
    public AudioClip shieldTouch,hitKepala,hitBadan,soundPoison;
	AudioSource myAudioSource;
    public GameObject cowok, cewek;
	public int damageKepala;
	public int damageBadan;
	public int count;
   
    // Use this for initialization
    void Start () {
		count = 0;
		myAudioSource = GetComponent<AudioSource> ();
        
	}
	//method di bawah ini digunakan saat bantal menyentuh objek lain seperti player cowok dan cewek tetapi selain kasur 
	void OnTriggerEnter2D(Collider2D other){	
        if (other.tag != gameObject.tag) {
			Debug.Log(other.gameObject.name);
            Vector3 damagePos = other.GetComponentInParent<Transform>().position;
            damagePos.y += 1.5f;
            AudioSource otherSound = other.GetComponentInParent<AudioSource> ();
			if (other.GetComponentInParent<HealthPointPlayer>().isShield == false) {
                other.GetComponentInParent<Animator>().SetTrigger("Damage");
                if (cowok.GetComponent<PoisonScript>().addedPoison == true || cewek.GetComponent<PoisonScript>().addedPoison == true) {
                    other.GetComponentInParent<HealthPointPlayer>().playerPoisoned = true;
                }
                if (other.gameObject.name == "Kepala") {
					other.GetComponentInParent<HealthPointPlayer> ().healthPoint -= damageKepala;
					otherSound.clip = hitKepala;
					Debug.Log (damageKepala.ToString());
                    Instantiate(damage, damagePos, other.transform.rotation);
                } else if (other.gameObject.name == "Badan") {
					other.GetComponentInParent<HealthPointPlayer> ().healthPoint -= damageBadan;
					otherSound.clip = hitBadan;
					Debug.Log (damageBadan.ToString ());
				}
				otherSound.Play ();
            }
            else {
                other.GetComponentInParent<HealthPointPlayer>().healthPoint -= 0f;
				otherSound.clip = shieldTouch;
				otherSound.Play ();
            }

            GameController.adaBantal = false;
            cowok.GetComponent<PoisonScript>().addedPoison = false;
            cewek.GetComponent<PoisonScript>().addedPoison = false;
            Destroy(gameObject);
        }      
    }
    //method ini digunakan saat bantal menyentuh kasur yang ada di dalam arena kamar
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Kasur") {
            StartCoroutine(destroyWait(gameObject));
            GameController.adaBantal = false;
        }
    }
    //method ini digunakan untuk menunggu beberapa detik sebelum bantal di destroy dari scene;
    IEnumerator destroyWait(GameObject bantal) {
        yield return new WaitForSeconds(1);
        Destroy(bantal);
    }

    //method ini digunakan untuk menunggu beberapa detik sebelum efek suara poison dihidupkan
	IEnumerator soundPoisonStart(){
		yield return new WaitForSeconds (1);
	}

}
