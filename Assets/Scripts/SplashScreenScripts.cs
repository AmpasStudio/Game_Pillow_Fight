using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenScripts : MonoBehaviour {
    public string scene;
	public Image objectSplash;
	IEnumerator Start(){
	    objectSplash.canvasRenderer.SetAlpha (0.0f);
		FadeIn ();
		yield return new WaitForSeconds (3.5f);
		FadeOut ();
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	void FadeIn(){
		objectSplash.CrossFadeAlpha (1.0f, 1.5f, false);
	}
	void FadeOut(){
		objectSplash.CrossFadeAlpha (0f, 1.5f, false);
	}
}
