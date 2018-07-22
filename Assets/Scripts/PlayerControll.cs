using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {
    GameObject cloneIcon;
    bool adaIcon;
    public GameObject poisonIcon,twiceIcon;
    private Vector3 poisonIconPos;
    public AudioClip lemparJauh;
	public AudioClip lemparDekat;
    public GameObject cursor;
	public GameObject barCharge;
	public GameObject barPower;
	public GameObject Enemy;
	public GameObject bantal;
	private AudioSource myAudioSource;
    public Button enemyHealButton;
    public Button myHealButton;
    public Button enemyTwiceButton;
    public Button myTwiceButton;
    public Button enemyPoisonButton;
    public Button myPoisonButton;
    public Button myShieldButton;
    public Button enemyShieldButton;
    Vector2 gerakan;
    float TimerTurn;
	float rasio=0.045f;
	public int speed;
	public float i=0;
	bool kurang;
   private Animator animatorSaya;
	// Use this for initialization
	void Start () {
        TimerTurn = 0;
        adaIcon = false;
        poisonIconPos = transform.position;
        poisonIconPos.y = transform.position.y + 3.5f;
        animatorSaya = GetComponent<Animator>();
        barPower.transform.localScale =new Vector3 (1, i, 1);
		kurang = false;
        myHealButton.enabled = true;
        enemyHealButton.enabled = false;
        myTwiceButton.enabled = true;
        enemyTwiceButton.enabled = false;
        enemyPoisonButton.enabled = false;
        myPoisonButton.enabled = true;
        myShieldButton.enabled = true;
        enemyShieldButton.enabled = false;
		myAudioSource = GetComponent<AudioSource> ();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0) && Time.timeScale == 1 && GameController.adaBantal == false) {
            animatorSaya.SetBool("Lempar", false);
            animatorSaya.SetBool("Ancang2", true);
            barCharge.SetActive(true);
            barPower.transform.localScale = new Vector3(1, i, 1);
            barPower.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(Color.yellow, Color.red, i);
            if (i <= 1 && kurang == false) {
                i += rasio;
                if (i >= 1) {
                    kurang = true;
                }
            }
            if (kurang == true) {
                i -= rasio;
                if (i <= 0) {
                    kurang = false;
                }
            }
            TimerTurn = 0;
            TimerTurn += 0;

        }
        if (Input.GetMouseButtonUp(0) && Time.timeScale == 1 && GameController.adaBantal == false) {
           animatorSaya.SetBool("Lempar", true);
           animatorSaya.SetBool("Ancang2", false);
            if (animatorSaya.GetBool("Lempar") == true) {
                //Tembak((13.4f-GameController.angin)/18);
                Tembak(i);
                //i akan tepat sasaran jika bernilai 0.76
                if (SkillScript.twice == true) {
                    StartCoroutine(Example(i));
                   
                }              
                GameController.adaBantal = true;
            }
           // Tembak(i);
            barCharge.SetActive(false);
			i = 0;
            if (adaIcon) {
                Destroy(cloneIcon);
                adaIcon = false;
            }
        }
        if (gameObject.GetComponent<PlayerControll>().enabled == false) {
            Enemy.GetComponentInChildren<Collider2D>().enabled = true;
            Enemy.GetComponent<PlayerControll>().enabled = true;
            enemyHealButton.enabled = true;
            myHealButton.enabled = false;
            myTwiceButton.enabled = false;
            enemyTwiceButton.enabled = true;
            myPoisonButton.enabled = false;
            enemyPoisonButton.enabled = true;
            enemyShieldButton.enabled = true;
            myShieldButton.enabled = false;
            cursor.SetActive(false);
            Debug.Log("Active");

        }
        else {
            Enemy.GetComponentInChildren<Collider2D>().enabled = false    ;
            Enemy.GetComponent<PlayerControll>().enabled =false;
            enemyHealButton.enabled = false;
            myHealButton.enabled = true;
            myTwiceButton.enabled = true;
            enemyTwiceButton.enabled = false;
            myPoisonButton.enabled = true;
            enemyPoisonButton.enabled = false;
            enemyShieldButton.enabled = false;
            myShieldButton.enabled = true;
            cursor.SetActive(true);
            if (gameObject.GetComponent<HealthPointPlayer>().isShield == true && GameController.adaBantal==false) {
                gameObject.GetComponent<HealthPointPlayer>().isShield = false;
                Destroy(HealthPointPlayer.shieldObjectClone);
            }
            if (GameController.adaBantal == false) {
                TimerTurn += Time.deltaTime;
            }
            
            if (TimerTurn >= 5f) {
                
                Tembak(Random.Range(0.5f, 1f));
               
                if (SkillScript.twice == true) {
                    StartCoroutine(Example(Random.Range(0.5f, 1f)));

                }
                TimerTurn = 0;
                gameObject.GetComponent<PlayerControll>().enabled = false;
                gameObject.GetComponentInChildren<Collider2D>().enabled = false;
                Enemy.GetComponentInChildren<Collider2D>().enabled = true;
                Enemy.GetComponent<PlayerControll>().enabled = true;
            }
            
        }
        
        
	}
	void Tembak(float speed){
		if (tag == "laki") {
			bantal.GetComponent<MoverBantal> ().Direction = 1;
		} else if (tag == "perempuan") {
			bantal.GetComponent<MoverBantal> ().Direction = -1;
		}
		bantal.GetComponent<MoverBantal> ().power = speed*30;
		Instantiate (bantal, transform.position, transform.rotation);
        gameObject.GetComponent<PlayerControll>().enabled = false;
        gameObject.GetComponentInChildren<Collider2D>().enabled = false;
       
        barCharge.SetActive (false);
        
	}
    IEnumerator Example(float speed) {
        yield return new WaitForSeconds(1);
        Tembak(speed);
        SkillScript.twice = false;
    }
    
    public void PoisonIconShow() {
        adaIcon = true;
        cloneIcon = Instantiate(poisonIcon, poisonIconPos, transform.rotation);
    }
    public void TwiceIconShow() {
        adaIcon = true;
        cloneIcon = Instantiate(twiceIcon, poisonIconPos, transform.rotation);
    }
}
