using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmlclock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float detectRange;
    public LayerMask layerMask;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float dmg;
    public bool boom = false;
    public AudioSource audioSource;
    // Update is called once per frame
    void Update()
    {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, detectRange, layerMask);
            if (hitEnemies.Length > 0&&!boom )
            {
               animator.SetBool("blow",true);
                boom =true;
                audioSource.Play();
            }
            
    }

    void explode(){
         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, detectRange, layerMask);
            foreach(Collider2D enemy in hitEnemies){
                if(enemy.GetComponent<PlayerHealthManager>()!=null){
                    enemy.GetComponent<PlayerHealthManager>().takeDamage(dmg);
                   
                   
                }
                 enemy.GetComponent<AudioManager>().play("boom");
                 Destroy(gameObject);
            }
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,detectRange);
    }
}
