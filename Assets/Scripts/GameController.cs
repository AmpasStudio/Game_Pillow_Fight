using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static AudioSource PoisonAudio;
    bool isActiveOnce;
    public GameObject cursorCewek;
    public GameObject cursorCowok;
    public GameObject BarAngin;
    public Sprite[] anginSprite;
    private GameObject arenaKamar;
    public GameObject gameOverObject;
    public static bool adaBantal;
    public static bool isOver;
    public GameObject awan1;
    public GameObject awan2;
    public static int cewekHealCount;
    public static int cowokHealCount;
	public static string pemenang;
	public GameObject Ibu;
	public static int angin;
	public static bool diLuar;
	public GameObject[] ArenaBG;
	public GameObject cowok;
	public GameObject cewek;
	public float Timer;
    public static int cowokTwiceCount;
    public static int cewekTwiceCount;
    public static int cowokPoisonCount;
    public static int cewekPoisonCount;
    public static int cowokShieldCount;
    public static int cewekShieldCount;
    /*---------------Scene Pilih Bantal--------------------------*/
    public static int cowokSkillCount;
    public static bool cowokIsHealChoosen;
    public static bool cowokIsTwiceChoosen;
    public static bool cowokIsPoisonChoosen;
    public static bool cowokIsShieldChoosen;
    public static bool cowokCompleteSkill;
    public static bool cowokTurnChooseSkill;
    public static int cewekSkillCount;
    public static bool cewekIsHealChoosen;
    public static bool cewekIsTwiceChoosen;
    public static bool cewekIsPoisonChoosen;
    public static bool cewekIsShieldChoosen;
    public static bool cewekCompleteSkill;
    public static bool cewekTurnChooseSkill;
    /*-----------------------------------------------------------*/
    // Use this for initialization
    void Start () {
		PoisonAudio = GetComponent<AudioSource> ();
        cowokSkillCount = 0;
        cewekSkillCount = 0;
        gameOverObject.SetActive(false);
        pemenang = "";
        isOver = false;
        adaBantal = false;
        cewekHealCount = 0;
        cowokHealCount = 0;
        cowokTwiceCount = 0;
        cewekTwiceCount = 0;
        cowokPoisonCount = 0;
        cewekPoisonCount = 0;
        cowokShieldCount = 0;
        cewekShieldCount = 0;
		cewek.GetComponent<PlayerControll> ().enabled = false;
		cowok.GetComponent<PlayerControll> ().enabled = true;
		Instantiate (ArenaBG [Arena.pilihanArena], transform.position, transform.rotation);
		if (Arena.pilihanArena == 1) {
			diLuar = false;
			BarAngin.SetActive (false);
            angin = 0;
		} else {
			diLuar = true;
            Destroy(Ibu);
		}

		if (diLuar == true) {
			aturAngin ();
			if (Arena.pilihanArena == 0) {
				Timer = 10.0f;
			}
		} else {
			Timer = 10.0f;
		}
        if (Arena.pilihanArena != 0) {
            Destroy(awan1);
            Destroy(awan2);
        }

      
    }
	
	// Update is called once per frame
	void Update () {
        
		if (diLuar == true) {
            BarAngin.GetComponent<SpriteRenderer>().sprite = anginSprite[Mathf.Abs(angin)];
            if (angin < 0) {
                BarAngin.transform.localScale = new Vector3(-1, 1, 1);
            }
            else {
                BarAngin.transform.localScale = new Vector3(1, 1, 1);
            }
		}
		if (diLuar == false) {
			Timer -= Time.deltaTime;
			if (Timer < 1.0f) {
				Timer = Random.Range(15,30);
                arenaKamar = GameObject.FindGameObjectWithTag("Kasur");
                arenaKamar.GetComponent<Animator>().SetBool("TutupPintu", false);
                arenaKamar.GetComponent<Animator>().SetBool("BukaPintu", true);
                StartCoroutine(Test());
                Vector2 ibuMuncul = transform.position;
                ibuMuncul.x = transform.position.x - 4.28f;
                
				
			}
		}
		if (Arena.pilihanArena == 0) { //0 menunjukkan index untuk arena di atap
			Timer -= Time.deltaTime;

			if (Timer < 1.0f) {
				Timer = Random.Range(15,30);
				cewek.GetComponent<HealthPointPlayer>().healthPoint -= 5;
				cowok.GetComponent<HealthPointPlayer>().healthPoint -= 5;
			}
		}
		if (cewek.GetComponent<HealthPointPlayer> ().healthPoint > cowok.GetComponent<HealthPointPlayer> ().healthPoint && isOver==true&&isActiveOnce==false) {
			pemenang = "cewek";
            gameOverObject.SetActive(true);
            isActiveOnce = true;
            
           
        } else if(isOver==true && isActiveOnce==false){
			pemenang = "cowok";
            gameOverObject.SetActive(true);
            isActiveOnce = true;
            
        }
        if (isOver == true) {
            cewek.GetComponent<PlayerControll>().enabled = false;
            cowok.GetComponent<PlayerControll>().enabled = false;
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
        if (cewek.GetComponent<PlayerControll>().enabled == true) {
            cursorCewek.SetActive(true);
            cursorCowok.SetActive (false);
        }
        else if (cowok.GetComponent<PlayerControll>().enabled==true) {
            cursorCewek.SetActive(false);
            cursorCowok.SetActive(true);
        }
	}
	public static void aturAngin(){
		if (GameController.diLuar == true) {
			GameController.angin = Random.Range (-6, 6);
            Debug.Log(GameController.angin);
		};

	}
    //method di bawah ini saat ibu muncul di scene yang arenanya di dalam kamar
    IEnumerator Test() {
        yield return new WaitForSeconds(0.2f);
        Ibu.SetActive(true);
        cewek.GetComponent<HealthPointPlayer>().healthPoint -= 5;
        cowok.GetComponent<HealthPointPlayer>().healthPoint -= 5;
        yield return new WaitForSeconds(3);
        arenaKamar.GetComponent<Animator>().SetBool("BukaPintu", false);
        arenaKamar.GetComponent<Animator>().SetBool("TutupPintu", true);
        Ibu.SetActive(false);
        
    }
}
