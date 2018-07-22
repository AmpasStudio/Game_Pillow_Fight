using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneScripts : MonoBehaviour {
    public GameObject pauseMenu,gameOverMenu;
    public GameObject loadingScreenObject;
    AsyncOperation ao;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (loadingScreenObject.activeInHierarchy == true) {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            gameOverMenu.SetActive(false);
        }
	}
    public void LoadScene(int index) {
        loadingScreenObject.SetActive(true);
        StartCoroutine(Scene(index));
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public IEnumerator Scene(int indexpage) {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        ao = SceneManager.LoadSceneAsync(indexpage);
        ao.allowSceneActivation = false;
        loadingScreenObject.GetComponentInChildren<Text>().text = "Loading..."+"\n" + Mathf.RoundToInt(ao.progress * 100f) + "%";
        while (!ao.isDone) {
            Debug.Log(Mathf.RoundToInt(ao.progress*100)+"%");
            loadingScreenObject.GetComponentInChildren<Text>().text = "Loading..."+"\n \n" + Mathf.RoundToInt(ao.progress * 100f) + "%";
            if (ao.progress >= 0.9f) {
                ao.allowSceneActivation = true;
            }
            yield return null;
            
        }

	
      
    }
	public void ToScreen(string nameScene){
		SceneManager.LoadScene (nameScene, LoadSceneMode.Single);
	}
}
