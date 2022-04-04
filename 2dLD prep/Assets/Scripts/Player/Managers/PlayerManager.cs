using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player{
public class PlayerManager : MonoBehaviour
{
    public PauseMenu PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
      
        
        PauseMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

    }
    void HandleInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)&&PauseMenu!=null)
        {
            Debug.Log("pause");
            if (!PauseMenu.gameObject.activeSelf)
            {
               
                PauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                
                PauseMenu.gameObject.SetActive(false);
                 Time.timeScale = 1;
            }
        }
    }
}
}