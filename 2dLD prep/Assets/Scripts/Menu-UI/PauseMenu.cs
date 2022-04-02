using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PauseMenu : MonoBehaviour
{
  public AudioMixer audioMixer;
  public void quit(){
      Application.Quit();
  }
  public void returnToMainMenu(){
      SceneManager.LoadScene("MainMenu");
  }
  public void setVolume(float volume){
    audioMixer.SetFloat("volume",volume);
  }
    
  
}
