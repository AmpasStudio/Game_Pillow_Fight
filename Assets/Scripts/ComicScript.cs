using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ComicScript : MonoBehaviour {
    public Button Next, Previous,Play;
    public Sprite[] ComicSprite;
    int pages;
    bool showPlayButton;
    public Image Comic;
    private void Start() {
        pages = 0;
        showPlayButton = false;
        Comic.sprite = ComicSprite[pages];
    }
    private void Update() {
        Comic.sprite = ComicSprite[pages];
        if (pages == 3) {
            Next.gameObject.SetActive(false);
            Previous.gameObject.SetActive(true);
        }else if (pages == 0) {
            Next.gameObject.SetActive(true);
            Previous.gameObject.SetActive(false);
        }
        else {
            Next.gameObject.SetActive(true);
            Previous.gameObject.SetActive(true);
        }


        if (showPlayButton == true) {
            Play.gameObject.SetActive(true);
        }
        else {
            Play.gameObject.SetActive(false);
        }
        
    }
    public void NextPage(string command) {
        if (pages <= 3 && pages >= 0) {
            if (command == "next") {
                pages++;
            }else if (command == "previous") {
                pages--;
            }
        }

        if (pages == 3) {
            showPlayButton = true;
        }
        Comic.gameObject.GetComponent<Animator>().SetTrigger("ChangePage");
    }
    public void StartGame() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
