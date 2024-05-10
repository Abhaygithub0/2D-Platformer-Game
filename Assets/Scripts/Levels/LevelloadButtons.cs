using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelloadButtons : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField]private string scenename;
    
 
   
private void Start() {

    button.onClick.AddListener(playscene);
}

    private void playscene()
    {
        Image imagecolor = GetComponent<Image>();
        Levelstatus levelstatus= LevelManager.Instance.GetLevelStatus(scenename);
        switch(levelstatus)
        {
            case Levelstatus.Locked:
            SoundManager.Instance.play(soundplaces.levellocked);
            Debug.Log("cant play");
            break;
            case Levelstatus.Unlocked:
            SoundManager.Instance.play(soundplaces.levelunloced);
           imagecolor.color=Color.white;
            SceneManager.LoadScene(scenename);
            break;
            case Levelstatus.Completed:
            SoundManager.Instance.play(soundplaces.levelunloced);
            imagecolor.color = Color.blue;
            SceneManager.LoadScene(scenename);
            break;
            
        }
        
    }

   
}