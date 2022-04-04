using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingClock : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed,circleRaidus;
    private Rigidbody2D enemyRB;
    public GameObject rightCheck,RoofCheck,GroundCheck;
    public LayerMask groundLayer;
    public bool facingRight = true, groundTouch,RoofTouch,RightTouch;
    public float dirX = 1, dirY = 0.25f;
    public float dmg;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.velocity =  new Vector2(dirX,dirY)*speed *Time.deltaTime;
        HitDetection();
        if(RightTouch){
            facingRight = !facingRight;
        }
    }
    void HitDetection(){
        RightTouch = Physics2D.OverlapCircle(rightCheck.transform.position,circleRaidus,groundLayer);
        RoofTouch = Physics2D.OverlapCircle(RoofCheck.transform.position,circleRaidus,groundLayer);
        groundTouch = Physics2D.OverlapCircle(GroundCheck.transform.position,circleRaidus,groundLayer);
        hitLogic();
    }
    void hitLogic(){
        if(RightTouch &&facingRight){
            flip();
        }
         if ( RightTouch &&!facingRight){
                flip();
        }
        if(RoofTouch){
            dirY= -0.25f;
        }else if (groundTouch){
           dirY = 0.25f;
        }
    }
    void flip(){
       facingRight = !facingRight;
       transform.Rotate(new Vector3(0,180,0));
       dirX = -dirX;
    }
     void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rightCheck.transform.position,circleRaidus);
        Gizmos.DrawWireSphere(RoofCheck.transform.position,circleRaidus);
        Gizmos.DrawWireSphere(GroundCheck.transform.position,circleRaidus);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.GetComponent<PlayerHealthManager>()!=null){
            PlayerHealthManager ph = collisionInfo.gameObject.GetComponent<PlayerHealthManager>();
            ph.takeDamage(dmg);
        }
    }
}
