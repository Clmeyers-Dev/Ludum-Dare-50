using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PauseMenu PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu = GetComponentInChildren<PauseMenu>();
        if(PauseMenu!=null)
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
            if (!PauseMenu.gameObject.activeSelf)
            {
               
                PauseMenu.gameObject.SetActive(true);
            }
            else
            {
                
                PauseMenu.gameObject.SetActive(false);
            }
        }
    }
}
