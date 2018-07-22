using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillScript : MonoBehaviour {
	public AudioClip soundHealing;
	public AudioClip soundShieldActive;
    public ParticleSystem healingEffect;
    public GameObject cewekPoison;
    public GameObject cowokPoison;
    public static bool twice;
    public bool healing;
    public Button healButton;
    public Button twiceButton;
    public Button poisonButton;
    public Button shieldButton;
    public Sprite activeSprite;
    public Sprite disabledTwiceButton;
    public Sprite poisonDisabled;
    public Sprite shieldDisabled;
   
    // Use this for initialization
    void Start () {
        healing = false;
        twice = false;
        cewekPoison.GetComponent<PoisonScript>().addedPoison = false;
        cowokPoison.GetComponent<PoisonScript>().addedPoison = false;
        if ((GameController.cowokIsHealChoosen == false && healButton.tag == "laki") || GameController.cewekIsHealChoosen == false && healButton.tag == "perempuan") {
            //healButton.enabled = false;
            //healButton.image.sprite = activeSprite;
            healButton.gameObject.SetActive(false);
        }
        if ((GameController.cowokIsPoisonChoosen == false && poisonButton.tag == "laki") || GameController.cewekIsPoisonChoosen == false && poisonButton.tag == "perempuan") {
            // poisonButton.enabled = false;
            // poisonButton.image.sprite = poisonDisabled;
            poisonButton.gameObject.SetActive(false);
        }
        if ((GameController.cowokIsTwiceChoosen == false && twiceButton.tag == "laki") || GameController.cewekIsTwiceChoosen == false && twiceButton.tag == "perempuan") {
            //twiceButton.enabled = false;
            //twiceButton.image.sprite = disabledTwiceButton;
            twiceButton.gameObject.SetActive(false);
        }
        if ((GameController.cowokIsShieldChoosen == false && shieldButton.tag == "laki") || GameController.cewekIsShieldChoosen == false && shieldButton.tag == "perempuan") {
            shieldButton.gameObject.SetActive(false);
        }
    }
    void Update() {
        if ((GameController.cewekPoisonCount > 0 && gameObject.tag == "perempuan") || (GameController.cowokPoisonCount > 0 && gameObject.tag == "laki")) {
            poisonButton.enabled = false;
        }
        if ((GameController.cowokHealCount > 0 && gameObject.tag == "laki") || (GameController.cewekHealCount > 0 && gameObject.tag == "perempuan")) {
            healButton.enabled = false;
        }
        if ((GameController.cowokTwiceCount > 0 && gameObject.tag == "laki") || (GameController.cewekTwiceCount > 0 && gameObject.tag == "perempuan")) {
            twiceButton.enabled = false;
        }
        if ((GameController.cowokShieldCount > 0 && gameObject.tag == "laki") || (GameController.cewekShieldCount > 0 && gameObject.tag == "perempuan")) {
            shieldButton.enabled = false;
        }

        

    }

    public void setHealing() {   
            healing = true;
            gameObject.GetComponent<PlayerControll>().enabled = false;
           if ((GameController.cewekHealCount==0&&gameObject.tag=="perempuan")||(GameController.cowokHealCount==0&&gameObject.tag=="laki")) {
                float addHp = 100f - gameObject.GetComponent<HealthPointPlayer>().healthPoint;

                if (addHp >= 20) {
                    gameObject.GetComponent<HealthPointPlayer>().healthPoint += 20;         
                }
                else {
                    gameObject.GetComponent<HealthPointPlayer>().healthPoint += addHp;                    
                }
                healButton.enabled = false;
                 
                if (gameObject.tag == "perempuan") {
                    GameController.cewekHealCount++;
                    
                }
                else {
                    GameController.cowokHealCount++;
                }
            
				AudioSource heal= GetComponent<AudioSource> ();
				heal.clip = soundHealing;
				heal.Play ();
			if (GameSettings.VFXTurnOn == true) {
				StartCoroutine(DestroyHealing());
			}
           		
            
            }
            
            healing = false;
            healButton.image.sprite = activeSprite;
        if(GamePause.currentTurn == "cewek") {
            GamePause.currentTurn = "cowok";
        }
        else {
            GamePause.currentTurn = "cewek";
        }
    }
    public void setTwice() {
        if ((GameController.cewekTwiceCount == 0 && gameObject.tag == "perempuan") || (GameController.cowokTwiceCount== 0 && gameObject.tag == "laki")) {
            twice = true;
            twiceButton.enabled = false;
            twiceButton.image.sprite = disabledTwiceButton;
            if (gameObject.tag == "perempuan") {
                GameController.cewekTwiceCount++;
            }
            else {
                GameController.cowokTwiceCount++;
            }
        }
    }
    public void addPoison() {
        if ((GameController.cewekPoisonCount == 0 && gameObject.tag == "perempuan") || (GameController.cowokPoisonCount == 0 && gameObject.tag == "laki")) {
            poisonButton.image.sprite = poisonDisabled;
            poisonButton.enabled = false;
            if (gameObject.tag == "perempuan") {
                cewekPoison.GetComponent<PoisonScript>().addedPoison = true;
                GameController.cewekPoisonCount++;
            }
            else {
                cowokPoison.GetComponent<PoisonScript>().addedPoison = true;
                GameController.cowokPoisonCount++;
            }
        }
    }
    public void activeShield() {
        if ((GameController.cowokShieldCount == 0 && gameObject.tag == "laki") || (GameController.cewekShieldCount == 0 && gameObject.tag == "perempuan")) {
            gameObject.GetComponent<HealthPointPlayer>().isShield = true;
            if (GamePause.currentTurn == "cewek") {
                GamePause.currentTurn = "cowok";
                GameController.cewekShieldCount++;
            }
            else {
                GamePause.currentTurn = "cewek";
                GameController.cowokShieldCount++;
            }
            shieldButton.image.sprite = shieldDisabled;
			AudioSource shield = GetComponent<AudioSource> ();
			shield.clip = soundShieldActive;
			shield.Play ();
        }
    }

    IEnumerator DestroyHealing() {
		

        ParticleSystem cloneParticle=Instantiate(healingEffect, gameObject.GetComponent<Transform>().position, healingEffect.transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(cloneParticle);
    }
    
}
