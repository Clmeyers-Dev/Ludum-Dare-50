using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneEnum sceneToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadWithbutton(){
        PlayerHealthManager playman = FindObjectOfType<PlayerHealthManager>();
       if(playman!=null){
        playman.savePlayer();
       }
        Load.LoadThis(sceneToLoad);
    }
    void OnCollisionEnter2D(Collision2D col){
        PlayerHealthManager playman = FindObjectOfType<PlayerHealthManager>();
        playman.savePlayer();
        Debug.Log("onCollision");
        if(col.transform.tag == "Player"){
        Load.LoadThis(sceneToLoad);
        }
    }
    void OnTriggerEnter2D(Collider2D col){
       
        PlayerHealthManager playman = FindObjectOfType<PlayerHealthManager>();
        playman.savePlayer();
        
        if(col.transform.tag == "Player"){
             Debug.Log("on trigger");
        Load.LoadThis(sceneToLoad);
        }
    }
    public void loadWithCode(){
         PlayerHealthManager playman = FindObjectOfType<PlayerHealthManager>();
       if(playman!=null){
        playman.savePlayer();
       }
        Load.LoadThis(sceneToLoad);
    }
    
}
