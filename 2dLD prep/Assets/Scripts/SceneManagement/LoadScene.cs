using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using System;
public static class Load
{

   
    private static Action onLoaderCallBack;
    public static void LoadThis(SceneEnum scene){
       
      

        SceneManager.LoadScene(scene.ToString());
        
    }
 public static void LoaderCallback(){
     if(onLoaderCallBack !=null){
         onLoaderCallBack();
         onLoaderCallBack = null;
     }
 }
}
 public enum SceneEnum{
        
        MainMenu,
        Loading,
        LevelOne,
        LevelTwo
        

        
    }