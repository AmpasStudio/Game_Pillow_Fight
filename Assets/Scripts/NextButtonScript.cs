using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonScript : MonoBehaviour {
    
    public GameObject[] ceklis;
    public Button buttonNext;
    public GameObject cewekIcon;
    public GameObject cowokIcon, player;
    public Sprite player2Title;
    public Sprite player1Title;
    public GameObject scriptLoader;
    // Use this for initialization
    void Start() {
        GameController.cewekSkillCount = 0;
        GameController.cowokSkillCount = 0;
        GameController.cowokIsHealChoosen = false;
        GameController.cowokIsTwiceChoosen = false;
        GameController.cowokIsShieldChoosen = false;
        GameController.cowokIsPoisonChoosen = false;
        GameController.cewekIsHealChoosen = false;
        GameController.cewekIsTwiceChoosen = false;
        GameController.cewekIsShieldChoosen = false;
        GameController.cewekIsPoisonChoosen = false;
        GameController.cowokCompleteSkill = false;
        GameController.cowokTurnChooseSkill = true;
        GameController.cewekTurnChooseSkill = false;
        Debug.Log(GameController.cowokSkillCount.ToString());
        Debug.Log(GameController.cowokTurnChooseSkill);
    }

    // Update is called once per frame
    void Update() {
        if ((GameController.cowokSkillCount < 2 && GameController.cowokTurnChooseSkill==true)) {
            buttonNext.gameObject.SetActive(false);
            GameController.cowokCompleteSkill = false;
            GameController.cowokTurnChooseSkill = true;
        }
        else if (GameController.cowokTurnChooseSkill==true) {
            buttonNext.gameObject.SetActive(true);
           
        }
        if ((GameController.cewekSkillCount < 2 && GameController.cewekTurnChooseSkill == true)) {
            buttonNext.gameObject.SetActive(false);
            GameController.cewekCompleteSkill = false;
            GameController.cewekTurnChooseSkill = true;
        }
        else if (GameController.cewekTurnChooseSkill) {
            buttonNext.gameObject.SetActive(true);

        }
        if (GameController.cowokTurnChooseSkill == true) {
            cowokIcon.SetActive(true);
            cewekIcon.SetActive(false);
            player.GetComponent<SpriteRenderer>().sprite = player1Title;
        }
        else {
            cewekIcon.SetActive(true);
            cowokIcon.SetActive(false);
            player.GetComponent<SpriteRenderer>().sprite = player2Title;
        }
        
	}
    public void ResetSkill() {
        if (GameController.cowokCompleteSkill == false) {
            GameController.cowokIsHealChoosen = false;
            GameController.cowokIsTwiceChoosen = false;
            GameController.cowokIsShieldChoosen = false;
            GameController.cowokIsPoisonChoosen = false;
            GameController.cowokSkillCount = 0;
        }else if (GameController.cewekCompleteSkill == false) {
            GameController.cewekIsHealChoosen = false;
            GameController.cewekIsTwiceChoosen = false;
            GameController.cewekIsShieldChoosen = false;
            GameController.cewekIsPoisonChoosen = false;
            GameController.cewekSkillCount = 0;
        }
    }
    public void changePage() {
        SceneManager.LoadScene("Set", LoadSceneMode.Single);
    }
    public void clickNext() {
        if (GameController.cowokSkillCount == 2) {
            GameController.cowokTurnChooseSkill = false;
            GameController.cowokCompleteSkill = true;
            GameController.cewekTurnChooseSkill = true;
            GameController.cewekCompleteSkill = false;
            foreach (GameObject _obj in ceklis) {

                _obj.SetActive(false);
            }
        }
        if (GameController.cewekSkillCount==2){
            //SceneManager.LoadScene("Set", LoadSceneMode.Single);
            scriptLoader.GetComponent<LoadingSceneScripts>().LoadScene(5);
            
            GameController.cewekTurnChooseSkill = false;
            GameController.cewekCompleteSkill = true;
        }
        buttonNext.gameObject.SetActive(false);
        
    }
}
