using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilihTalent : MonoBehaviour {
    public GameObject ceklis;
    Vector2 positionCeklis;
    public string namaSkill;
    private void Start() {
        positionCeklis = transform.position;
    }

    private void Update() {
        if (GameController.cowokTurnChooseSkill == true) {
            if (namaSkill == "heal" && GameController.cowokIsHealChoosen == false) {

                ceklis.SetActive(false);

            }

            else if (namaSkill == "twice" && GameController.cowokIsTwiceChoosen == false) {

                ceklis.SetActive(false);
            }
            else if (namaSkill == "poison" && GameController.cowokIsPoisonChoosen == false) {

                ceklis.SetActive(false);
            }
            else if (namaSkill == "shield" && GameController.cowokIsShieldChoosen == false) {

                ceklis.SetActive(false);
            }
        }
        else if(GameController.cewekTurnChooseSkill == true) {
            if (namaSkill == "heal" && GameController.cewekIsHealChoosen == false) {

                ceklis.SetActive(false);

            }

            else if (namaSkill == "twice" && GameController.cewekIsTwiceChoosen == false) {

                ceklis.SetActive(false);
            }
            else if (namaSkill == "poison" && GameController.cewekIsPoisonChoosen == false) {

                ceklis.SetActive(false);
            }
            else if (namaSkill == "shield" && GameController.cewekIsShieldChoosen == false) {

                ceklis.SetActive(false);
            }
        }

    }

    void OnMouseUp() {
        if (GameController.cowokSkillCount < 2 && GameController.cowokTurnChooseSkill==true) {
            positionCeklis.y += 1;
            if (namaSkill == "heal" && GameController.cowokIsHealChoosen == false) {
                GameController.cowokIsHealChoosen = true;
                ceklis.SetActive(true);
            }

            else if (namaSkill == "twice" && GameController.cowokIsTwiceChoosen == false) {
                GameController.cowokIsTwiceChoosen = true;
                ceklis.SetActive(true);
            }
            else if (namaSkill == "poison" && GameController.cowokIsPoisonChoosen == false) {
                GameController.cowokIsPoisonChoosen = true;
                ceklis.SetActive(true);
            }
            else if (namaSkill == "shield" && GameController.cowokIsShieldChoosen == false) {
                GameController.cowokIsShieldChoosen = true;
                ceklis.SetActive(true);
            }
            GameController.cowokSkillCount++;
        }else if(GameController.cewekSkillCount < 2 && GameController.cewekTurnChooseSkill == true) {
            if (namaSkill == "heal" && GameController.cewekIsHealChoosen == false) {
                GameController.cewekIsHealChoosen = true;
                ceklis.SetActive(true);
            }

            else if (namaSkill == "twice" && GameController.cewekIsTwiceChoosen == false) {
                GameController.cewekIsTwiceChoosen = true;
                ceklis.SetActive(true);
            }
            else if (namaSkill == "poison" && GameController.cewekIsPoisonChoosen == false) {
                GameController.cewekIsPoisonChoosen = true;
                ceklis.SetActive(true);
            }
            else if (namaSkill == "shield" && GameController.cewekIsShieldChoosen == false) {
                GameController.cewekIsShieldChoosen = true;
                ceklis.SetActive(true);
            }
            GameController.cewekSkillCount++;
        }
    }
    
}
