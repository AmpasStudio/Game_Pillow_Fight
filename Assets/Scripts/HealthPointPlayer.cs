using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPointPlayer : MonoBehaviour {
	public GameObject shieldObject;
	public AudioClip soundPoison;
	public ParticleSystem poisonParticle;
	ParticleSystem poisonEffect;
	public static GameObject shieldObjectClone;
	bool isInstance;
    public Image timerShield;
    public bool isShield;
    public bool playerPoisoned;
	public float healthPoint;
	public GameObject barHpCover;
	public Image barHp;
    public float timer;
    public float shieldTimer;
    float shieldBar = 7f;
	private bool isInstanceShield;
    private bool isPlay;
	private Vector3 shieldPos;

    //public GameObject barHpCewek;
    //public Image barHp;
    // Use this for initialization
    void Start () {
        isPlay = false;
		shieldPos = transform.position;
		shieldPos.y = transform.position.y + 3.5f;
		isInstanceShield = false;
		isInstance = false;
        isShield = false;
		healthPoint = 100f;
        playerPoisoned = false;
        timer = 0;
        shieldTimer = 0;

	}
	void Update(){
		if (healthPoint > 0) {
			barHp.rectTransform.localScale = new Vector3 (healthPoint / 100, 1, 1);
		}
		if (healthPoint <= 0 && GameController.isOver==false) {
            barHp.rectTransform.localScale = new Vector3(0, 1, 1);
            GameController.isOver = true;
            //SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);
		}
       
        if (playerPoisoned == true) {
			if (GameSettings.VFXTurnOn == true) {
				if (isInstance == false) {
					poisonEffect = Instantiate (poisonParticle,transform.position,poisonParticle.transform.rotation);		
					isInstance = true;
					

				}
			}
            if (isPlay == false) {
                GameController.PoisonAudio.Play();
                isPlay = true;
            }

            timer += Time.deltaTime;
            healthPoint -= 0.01f;
            if (timer >= 10f) {
                playerPoisoned = false;
                timer = 0;
				Destroy (poisonEffect);
            }
        }
        if (isShield == true) {
			if (isInstanceShield == false) {
				shieldObjectClone=Instantiate (shieldObject,shieldPos,transform.rotation);
				isInstanceShield = true;
			}
            /*shieldTimer += Time.deltaTime;
            timerShield.transform.parent.gameObject.SetActive(true);
            timerShield.gameObject.SetActive(true);
            shieldBar = shieldBar - 0.01f;
            timerShield.GetComponent<RectTransform>().localScale = new Vector3(shieldBar/7, 1, 1);
           
            
            //Debug.Log(shieldTimer.ToString());
            if (shieldBar<= 0) {
                isShield = false;
                Debug.Log("Shield Habis");
                timerShield.gameObject.SetActive(false);
                timerShield.transform.parent.gameObject.SetActive(false);
				Destroy (shieldObjectClone);
            }*/
            
        }

    }
	IEnumerator startSoundPoison(){
		yield return new WaitForSeconds (0.5f);
	}


}
