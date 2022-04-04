using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveSpot : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerHealthManager>() !=null){
            animator.SetBool("save",true);
            if(!audioSource.isPlaying)
            audioSource.Play();
            other.GetComponent<PlayerHealthManager>().savePlayer();
            other.GetComponent<PlayerHealthManager>().saveLocation();
        }
         
    }
    void endAnmation(){
        animator.SetBool("save",false);
    }
  
}
