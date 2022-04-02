using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float health;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(gameObject);
     }
}
