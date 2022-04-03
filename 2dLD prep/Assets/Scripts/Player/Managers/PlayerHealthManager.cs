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
public float TimeReaming = 300f;
[SerializeField]
private TextMeshProUGUI clock;
[SerializeField]
private GameObject damageNumbers;
[SerializeField]
private GameObject healNumbers;
[SerializeField]
private PlayerController playerController;
[SerializeField]
private float safeLocationYOffest;
[SerializeField]
private float safeLocationXOffest;

public Transform safeLocation;

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
     
        if(playerController.Grounded){
          
            if(transform.localScale.x ==1)
            safeLocation.transform.position = new Vector3(transform.position.x-safeLocationXOffest,transform.position.y- safeLocationYOffest,transform.position.z);
             if(transform.localScale.x ==-1)
            safeLocation.transform.position = new Vector3(transform.position.x+safeLocationXOffest,transform.position.y- safeLocationYOffest,transform.position.z);
        }
    }
    public void takeDamage(float dmg){
       var text =  Instantiate(damageNumbers,transform.position,Quaternion.identity);
       text.GetComponentInChildren<TextMesh>().text =  DisplayTime(dmg);
        TimeReaming -= dmg;
    }
    public void gainTime(float timeToGain){
        var text =  Instantiate(healNumbers,transform.position,Quaternion.identity);
       text.GetComponentInChildren<TextMesh>().text =  DisplayTime(timeToGain);
        TimeReaming += timeToGain;
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

    public void moveToSaveLocation(float dmg){
        takeDamage(dmg);
        transform.position = safeLocation.position;
    }
}
