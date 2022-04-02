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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime>0){
            currentTime -=Time.deltaTime;
        }else{
            lastPostion.position = transform.position;
            currentTime = rewindTime;
        }
        if( Input.GetKeyDown(KeyCode.T)){
            transform.position = lastPostion.position;
        }

        if(Input.GetKeyDown(KeyCode.W)&&!telo.inWall)
        {
            Debug.Log("teleport");
            transform.position = teleportPos.transform.position;
            healthManager.takeDamage(teleportCost);
        }
    }
}
