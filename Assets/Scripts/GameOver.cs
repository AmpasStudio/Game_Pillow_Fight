using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    bool iscreated;
    Vector2 pemenangPosition;
    public GameObject cewek;
    public GameObject cowok;
    // Use this for initialization
    private void Start() {
        iscreated = false;
    }
    void Update () {
        pemenangPosition = transform.position;
        pemenangPosition.y = transform.position.y + 0.5f;
        
        if (GameController.pemenang == "cewek" && GameController.isOver==true&& iscreated==false) {
            Instantiate(cewek, pemenangPosition, transform.rotation);
            iscreated = true;
            StartCoroutine(WaitFunction());
            

        }
        else if (GameController.isOver==true && iscreated==false){
            Instantiate(cowok, pemenangPosition, transform.rotation);
            iscreated = true;
            StartCoroutine(WaitFunction());
            
        }
	}
    //method di bawah ini digunakan untuk mereplay game saat setelah game over
	public void ClickMe () {
		SceneManager.LoadScene ("Set", LoadSceneMode.Single);
	}
    //method di bawah ini digunakan saat menekan tombol kembali ke menu utama game
	public void clickHome(){
        gameObject.SetActive(false);
	}
    //method di bawah ini digunakan saat menekan tombol kembali untuk memilih arena yang ada di menu game over 
	public void clickChooseArena(){
        gameObject.SetActive(false);
        SceneManager.LoadScene("PilihArena", LoadSceneMode.Single);
	}
    //method di bawah ini digunakan untuk menunggu selama beberapa detik lalu mengeset timescale menjadi 0
    IEnumerator WaitFunction() {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }
}
