using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class PlayerHealthManager : MonoBehaviour
{
    public float startTime = 300f;
[SerializeField]
public float TimeRemaing = 300f;
[SerializeField]
private TextMeshProUGUI clock;
[SerializeField]
private GameObject damageNumbers;
[SerializeField]
private GameObject healNumbers;
[SerializeField]
public PlayerController playerController;
[SerializeField]
private float safeLocationYOffest;
[SerializeField]
private float safeLocationXOffest;
public AudioManager am;
public Transform safeLocation;


    // Update is called once per frame
   
     public void savePlayer()
    {
        
       global.Instance.TimeRemaing = TimeRemaing;
       

    }
    public void saveLocation(){
 respawnLocation = transform.position;
global.Instance.respawnLocation = respawnLocation;
    }
    void Start()
    {
        if(global.Instance.TimeRemaing>0){
        TimeRemaing = global.Instance.TimeRemaing;
        }else{
            TimeRemaing = startTime;
        }
        
        if(global.Instance.respawnLocation!= new Vector3(0,0,0))
        transform.position = global.Instance.respawnLocation;
    }
    void Update()
    {
       
        if(TimeRemaing>0)
        {
            TimeRemaing -=Time.deltaTime;
        }else{
            die();
        }
        clock.text =  DisplayTime(TimeRemaing);
     
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
        TimeRemaing -= dmg;
        playerController.audioManager.play("hit");
    }
    public void gainTime(float timeToGain){
        var text =  Instantiate(healNumbers,transform.position,Quaternion.identity);
       text.GetComponentInChildren<TextMesh>().text =  DisplayTime(timeToGain);
        TimeRemaing += timeToGain;
    }
    private void die(){
      //  global.Instance.TimeRemaing = startTime;
        
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadSceneAsync(scene.name);
    }
    public Vector3 respawnLocation;
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
