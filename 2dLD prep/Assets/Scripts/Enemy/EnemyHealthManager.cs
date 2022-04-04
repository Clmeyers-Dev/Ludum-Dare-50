using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyHealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float health;
    [SerializeField]
    private float timeToGive;
public TextMeshPro clock;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock.text = DisplayTime(health);
     
    }
    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
         return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void TakeDamage(float dmg){
        health -= dmg;
        //play animation
        if(health <= 0){
            kill();
        }
    }
     void kill(){
         //play animation
         PlayerHealthManager ph = FindObjectOfType<PlayerHealthManager>();
    ph.gainTime(timeToGive);
    Destroy(transform.parent.gameObject);
        Destroy(gameObject);
     }
}
