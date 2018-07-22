using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour {
    public GameObject QuitQuestion;
    public Button[] allButton;
	// Use this for initialization
	void Start () {
        QuitQuestion.SetActive(false);
	}
	public void ClickStart(){
		SceneManager.LoadScene("PilihArena",LoadSceneMode.Single);
		Destroy (gameObject);
	}
	public void clickQuit(){
        QuitQuestion.SetActive(true);
        foreach(Button button in allButton) {
            button.enabled = false;
        }

	}
    public void QuitYes() {
        Application.Quit();
    }
    public void QuitNo() {
        QuitQuestion.SetActive(false);
        foreach (Button button in allButton) {
            button.enabled = true;
        }
    }
}
