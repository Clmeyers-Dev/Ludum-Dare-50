using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class global : MonoBehaviour
{
    // Start is called before the first frame update   public static GlobalControl Instance;

    public static global Instance;
    public float currentTime;
    public float volume;
    public GameObject Player;

    public Transform TransitionTarget;



    //Pseudo-singleton concept from Unity dev tutorial video:
    void Awake()
    {
        Player = FindObjectOfType<PlayerHealthManager>().gameObject;
        Application.targetFrameRate = 144;

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        if (TransitionTarget == null)
            TransitionTarget = gameObject.transform;

    }
}
