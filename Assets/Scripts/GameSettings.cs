using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class GameSettings : MonoBehaviour {
    public AudioMixer mainMixer;
    public Button exitButton;
	public static bool isMute=false;
	public static bool VFXTurnOn=true;
	public Slider volSlider;
	public Toggle muteToggle, VFXToggle;

    void Start() {
        Debug.Log(PlayerPrefs.GetInt("isSetVol").ToString());
        Debug.Log(PlayerPrefs.GetFloat("Volume").ToString());
        if (PlayerPrefs.GetInt("isSetVol") <= 0 && PlayerPrefs.GetFloat("Volume") <= 0) {
            mainMixer.SetFloat("volume", 2.0f);
            PlayerPrefs.SetFloat("Volume", 2.0f);
        }
        else  {
            mainMixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume"));
        }
       
        volSlider.value = PlayerPrefs.GetFloat("Volume");
        AudioListener.volume = volSlider.value;
        VFXToggle.isOn = VFXTurnOn;
    }

    public void SetVolume(float vol){
        mainMixer.SetFloat("volume", vol);
        PlayerPrefs.SetFloat("Volume", vol);
        AudioListener.volume = vol;
        PlayerPrefs.SetInt("isSetVol", 1);
        //Debug.Log(PlayerPrefs.GetFloat("Volume").ToString());
        //Debug.Log(PlayerPrefs.GetInt("isSetVol").ToString());
	}
    public void OnOffVFX(bool on) {
        VFXTurnOn = on;
    }



}
