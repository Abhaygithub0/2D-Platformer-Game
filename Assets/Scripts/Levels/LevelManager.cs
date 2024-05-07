using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    
    public string[] levels;
    public static LevelManager Instance {
         get {
             return instance;
             } 
         }

    private void Awake() {
        if (instance==null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        if(GetLevelstatus(levels[0])==Levelstatus.locked)
        {
           setLevelstatus(levels[0],Levelstatus.unlocked);
        }
    }

public void currentlevelcomleted()
{

    Scene currentscene = SceneManager.GetActiveScene();
    setLevelstatus(currentscene.name,Levelstatus.unlocked);
   int currentSceneIndex= Array.FindIndex(levels,level=>level==currentscene.name);
   int nextSceneIndex = currentSceneIndex+1;
   if(nextSceneIndex<levels.Length){
    setLevelstatus(levels[nextSceneIndex],Levelstatus.unlocked);
   }

    /* currentlevel = SceneManager.GetActiveScene().name;
     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
     nextlevel = SceneManager.GetActiveScene().name;
     if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
             nextlevel = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(nextSceneIndex));
            Debug.Log("Next scene name: " + nextlevel);
        }
        else
        {
            Debug.Log("No next scene found, this is the last scene.");
        }

        Instance.setLevelstatus(currentlevel,Levelstatus.completed);
        Instance.setLevelstatus(nextlevel,Levelstatus.unlocked);*/


}

     public Levelstatus GetLevelstatus(string level){
         Levelstatus levelstatus = (Levelstatus)PlayerPrefs.GetInt(level,0);
        return levelstatus;
    }

   public void setLevelstatus(string level, Levelstatus levelstatus)
   {
      PlayerPrefs.SetInt(level,(int)levelstatus);
      Debug.Log("level completed"+level+levelstatus);
   }
}

