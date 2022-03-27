using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
  public void quit(){
      Application.Quit();
  }
  public void returnToMainMenu(){
      SceneManager.LoadScene("MainMenu");
  }
}
