using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilities : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform lastPostion;
    [SerializeField]
    private float rewindTime;
    private float currentTime;
    [SerializeField]
    public Transform teleportPos;
    [SerializeField]
    private teleportMove telo;
    [SerializeField]
    private PlayerHealthManager healthManager;
    [SerializeField]
    private float teleportCost;
    [SerializeField]
    private LineRenderer line;
    public Transform origin;
    private SpriteRenderer rewindImage;
    [SerializeField]
    private SpriteRenderer playerSprite;
    public ParticleSystem teleportParticles;
    private float rewindTimeStamp;
    public SpriteRenderer telorender;
    void Start()
    {
      rewindImage =  lastPostion.GetComponent<SpriteRenderer>();
    telorender =   teleportPos.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        telorender.sprite = playerSprite.sprite;
        
        if(currentTime>0){
            currentTime -=Time.deltaTime;
        }else{
            lastPostion.position = transform.position;
            if(transform.localScale.x ==-1){
            rewindImage.flipX = true;
        }else{
            rewindImage.flipX = false;
        }
         rewindImage.sprite = playerSprite.sprite;
         rewindTimeStamp = healthManager.TimeRemaing;
            currentTime = rewindTime;
        }
        if( Input.GetKeyDown(KeyCode.S)){
            transform.position = lastPostion.position;
            healthManager.gainTime(rewindTimeStamp-healthManager.TimeRemaing);
            healthManager.TimeRemaing = rewindTimeStamp;
            
            currentTime = 0;
        }

        if(Input.GetKeyDown(KeyCode.W)&&!telo.inWall)
        {
            Debug.Log("teleport");
            transform.position = teleportPos.transform.position;
            teleportParticles.Play();
            healthManager.takeDamage(teleportCost);
        }
       line.SetPosition(0,new Vector3(origin.position.x, origin.position.y-lineOffsetY, origin.position.z));
       line.SetPosition(1, new Vector3(lastPostion.position.x, lastPostion.position.y-lineOffsetY, lastPostion.position.z));
    }
    [SerializeField]
    private float lineOffsetY;
}
