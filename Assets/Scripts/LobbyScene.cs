using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyScene : MonoBehaviour
{
   [SerializeField] Button play ,exit,rules,menu;
   public GameObject settingwindow,menuwindow,levelselection;

private void Start() {
    play.onClick.AddListener(playgame);
    exit.onClick.AddListener(exitgame);
    rules.onClick.AddListener(settings);
    menu.onClick.AddListener(menugame);
}
 
   

    void exitgame(){
         SoundManager.Instance.play(soundplaces.buttonclick);
        Debug.Log("ExitGame");
    }
    void playgame(){
        SoundManager.Instance.play(soundplaces.buttonclick);
        menuwindow.SetActive(false);
        settingwindow.SetActive(false);
        levelselection.SetActive(true);
    }
    void settings(){
         SoundManager.Instance.play(soundplaces.buttonclick);
        levelselection.SetActive(false);
         menuwindow.SetActive(false);
         settingwindow.SetActive(true);
       
    }
    void menugame(){
         SoundManager.Instance.play(soundplaces.buttonclick);
        levelselection.SetActive(false);  
         settingwindow.SetActive(false);
          menuwindow.SetActive(true);
        
    }
}
