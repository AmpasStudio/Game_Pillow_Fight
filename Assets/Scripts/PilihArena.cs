using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihArena : MonoBehaviour {
    public GameObject[] arena;
    private void Start() {
        Arena.pilihanArena = 1;
        Debug.Log(Arena.pilihanArena);
    }

    /*public void ArenaAtap(){
		Arena.pilihanArena = 0;//0 index untuk background atap
		SceneManager.LoadScene ("Set", LoadSceneMode.Single);
	}
	public void ArenaKamar(){
		Arena.pilihanArena = 1;//1 index untuk background Kamar
		SceneManager.LoadScene ("Set", LoadSceneMode.Single);
	}
	public void ArenaBelakang(){
		Arena.pilihanArena = 2;//2 index untuk background belakang
		SceneManager.LoadScene ("Set", LoadSceneMode.Single);
	}*/

    public void clickKanan() {
        if (Arena.pilihanArena < 2) {
            for(int i = 0; i < 3; i++) {
                arena[i].GetComponent<Transform>().Translate(-5.5f, 0, 0);
               

            }
            Arena.pilihanArena++;
        }
    }
    public void clickKiri() {
        if (Arena.pilihanArena > 0) {
            for (int i = 0; i < 3; i++) {
                arena[i].GetComponent<Transform>().Translate(5.5f, 0, 0);


            }
            Arena.pilihanArena--;
        }
       
    }
   
}
