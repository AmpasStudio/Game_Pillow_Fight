using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {
    public static string currentTurn;
    public static bool isShieldHealClick;
    bool isInstanceMenu = false;
    public GameObject cewek;
    public GameObject cowok;
    public GameObject pauseMenu;
    public GameObject GameOverMenu;
  
    // Update is called once per frame
    void Update() {
        if (pauseMenu.activeInHierarchy == true) {
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }
	}

    public void pause() {
        if (GameController.isOver == false) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    public void resume() {
        pauseMenu.SetActive(false);
        if (currentTurn == "cewek") {
            cewek.GetComponent<PlayerControll>().enabled = true;
            cowok.GetComponent<PlayerControll>().enabled = false;

        }
        else {
            cewek.GetComponent<PlayerControll>().enabled = false;
            cowok.GetComponent<PlayerControll>().enabled = true;
        }
    }
    public void pauseController() {
        if (cewek.GetComponent<PlayerControll>().enabled == true) {
            currentTurn ="cewek";
            
        }
        else if(cowok.GetComponent<PlayerControll>().enabled==true) {
            currentTurn = "cowok";
        }
        cewek.GetComponent<PlayerControll>().enabled = false;
        cowok.GetComponent<PlayerControll>().enabled = false;
        
    }
    public void resumeController() {
        if (currentTurn == "cewek") {
            cewek.GetComponent<PlayerControll>().enabled = true;
            cowok.GetComponent<PlayerControll>().enabled = false;

        }
        else {
            cewek.GetComponent<PlayerControll>().enabled = false;
            cowok.GetComponent<PlayerControll>().enabled = true;
        }
    }
    IEnumerator ShowMenu() {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        isInstanceMenu = true;
    }

    
    
}
