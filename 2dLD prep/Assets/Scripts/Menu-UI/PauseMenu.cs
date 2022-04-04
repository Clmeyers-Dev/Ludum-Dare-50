using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PauseMenu : MonoBehaviour
{
  public AudioMixer audioMixer;
  public float startTime;
  void Awake()
  {
    audioMixer.SetFloat("volume", global.Instance.volume);
  }
   public void savePlayer()
    {
       global.Instance.volume = -20;
      
    }
  public void PlayGame ()
  {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
     savePlayer();
  }
  public void quit(){
      Application.Quit();
  }
  public void restart(){
   Scene scene = SceneManager.GetActiveScene(); 
   global.Instance.respawnLocation = new Vector3(0,0,0);
   startTime = FindObjectOfType<PlayerHealthManager>().startTime;
   global.Instance.TimeRemaing = startTime;
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
  }
  public void returnToMainMenu(){
    savePlayer();
      SceneManager.LoadScene("MainMenu");
  }
  public void setVolume(float volume){
    audioMixer.SetFloat("volume",volume);
  }
    
  
}
