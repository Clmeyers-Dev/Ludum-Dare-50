using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class PlayerHealthManager : MonoBehaviour
{
[SerializeField]
private float TimeReaming = 300f;
[SerializeField]
private TextMeshProUGUI clock;
[SerializeField]
private GameObject damageNumbers;


    // Update is called once per frame
    void Update()
    {
        if(TimeReaming>0)
        {
            TimeReaming -=Time.deltaTime;
        }else{
            die();
        }
        clock.text =  DisplayTime(TimeReaming);
    }
    public void takeDamage(float dmg){
       var text =  Instantiate(damageNumbers,transform.position,Quaternion.identity);
       text.GetComponentInChildren<TextMesh>().text =  DisplayTime(dmg);
        TimeReaming -= dmg;
    }
    private void die(){
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
         return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
