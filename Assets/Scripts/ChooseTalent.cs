using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTalent : MonoBehaviour {
    public Image ceklis;
 
    public void chooseHeal() {
        if (GameController.cowokTurnChooseSkill == true) {
            if (GameController.cowokSkillCount < 2) {
                if (GameController.cowokIsHealChoosen == false) {
                    GameController.cowokIsHealChoosen = true;
                    GameController.cowokSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cowokIsHealChoosen = false;
                    GameController.cowokSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cowokSkillCount == 2 && GameController.cowokIsHealChoosen==true) {
                GameController.cowokIsHealChoosen = false;
                GameController.cowokSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cowokIsHealChoosen);
        }else if (GameController.cewekTurnChooseSkill == true) {
            if (GameController.cewekSkillCount < 2) {
                if (GameController.cewekIsHealChoosen == false) {
                    GameController.cewekIsHealChoosen = true;
                    GameController.cewekSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cewekIsHealChoosen = false;
                    GameController.cewekSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cewekSkillCount == 2 && GameController.cewekIsHealChoosen == true) {
                GameController.cewekIsHealChoosen = false;
                GameController.cewekSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cewekIsHealChoosen);
        }
    }
    public void chooseTwice() {
        if (GameController.cowokTurnChooseSkill == true) {
            if (GameController.cowokSkillCount < 2) {
                if (GameController.cowokIsTwiceChoosen == false) {
                    GameController.cowokIsTwiceChoosen = true;
                    GameController.cowokSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cowokIsTwiceChoosen = false;
                    GameController.cowokSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cowokSkillCount == 2 && GameController.cowokIsTwiceChoosen==true) {
                GameController.cowokIsTwiceChoosen = false;
                GameController.cowokSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cowokIsTwiceChoosen);
        }else if (GameController.cewekTurnChooseSkill == true) {
            if (GameController.cewekSkillCount < 2) {
                if (GameController.cewekIsTwiceChoosen == false) {
                    GameController.cewekIsTwiceChoosen = true;
                    GameController.cewekSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cewekIsTwiceChoosen = false;
                    GameController.cewekSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cewekSkillCount == 2 && GameController.cewekIsTwiceChoosen == true) {
                GameController.cewekIsTwiceChoosen = false;
                GameController.cewekSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cewekIsTwiceChoosen);
        }
    }
    public void choosePoison() {
        if (GameController.cowokTurnChooseSkill == true) {
            if (GameController.cowokSkillCount < 2) {
                if (GameController.cowokIsPoisonChoosen == false) {
                    GameController.cowokIsPoisonChoosen = true;
                    GameController.cowokSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cowokIsPoisonChoosen = false;
                    GameController.cowokSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cowokSkillCount == 2 && GameController.cowokIsPoisonChoosen==true) {
                GameController.cowokIsPoisonChoosen = false;
                GameController.cowokSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cowokIsPoisonChoosen);
        }else if (GameController.cewekTurnChooseSkill == true) {
            if (GameController.cewekSkillCount < 2) {
                if (GameController.cewekIsPoisonChoosen == false) {
                    GameController.cewekIsPoisonChoosen = true;
                    GameController.cewekSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cewekIsPoisonChoosen = false;
                    GameController.cewekSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cewekSkillCount == 2 && GameController.cewekIsPoisonChoosen == true) {
                GameController.cewekIsPoisonChoosen = false;
                GameController.cewekSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cewekIsPoisonChoosen);
        }
    }
    public void chooseShield() {
        if (GameController.cowokTurnChooseSkill == true) {
            if (GameController.cowokSkillCount < 2) {
                if (GameController.cowokIsShieldChoosen == false) {
                    GameController.cowokIsShieldChoosen = true;
                    GameController.cowokSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cowokIsShieldChoosen = false;
                    GameController.cowokSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cowokSkillCount == 2 && GameController.cowokIsShieldChoosen == true) {
                GameController.cowokIsShieldChoosen = false;
                GameController.cowokSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cowokIsShieldChoosen);
        }
        else if (GameController.cewekTurnChooseSkill == true) {
            if (GameController.cewekSkillCount < 2) {
                if (GameController.cewekIsShieldChoosen == false) {
                    GameController.cewekIsShieldChoosen = true;
                    GameController.cewekSkillCount++;
                    ceklis.gameObject.SetActive(true);
                }
                else {
                    GameController.cewekIsShieldChoosen = false;
                    GameController.cewekSkillCount--;
                    ceklis.gameObject.SetActive(false);
                }
            }
            else if (GameController.cewekSkillCount == 2 && GameController.cewekIsShieldChoosen == true) {
                GameController.cewekIsShieldChoosen = false;
                GameController.cewekSkillCount--;
                ceklis.gameObject.SetActive(false);
            }
            Debug.Log(GameController.cewekIsShieldChoosen);
        }
    }
}
