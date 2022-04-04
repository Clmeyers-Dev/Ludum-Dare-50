using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void play(string name){
     sound s =   Array.Find(sounds,sound => sound.name == name);
     if(s==null){
         return;
     }
     if(!s.source.isPlaying)
     s.source.Play();
    }
    public void stop(string name){
         sound s =   Array.Find(sounds,sound => sound.name == name);
     if(s==null){
         return;
     }
     if(s.source.isPlaying)
     s.source.Stop();
    }
}
