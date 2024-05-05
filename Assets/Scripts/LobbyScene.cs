using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyScene : MonoBehaviour
{
   [SerializeField] Button play ,exit,rules,menu;
   public GameObject settingwindow,menuwindow;

private void Start() {
    play.onClick.AddListener(playgame);
    exit.onClick.AddListener(exitgame);
    rules.onClick.AddListener(settings);
    menu.onClick.AddListener(menugame);
}
 
   

    void exitgame(){
        Debug.Log("ExitGame");
    }
    void playgame(){
        SceneManager.LoadScene(1);
    }
    void settings(){
         menuwindow.SetActive(false);
         settingwindow.SetActive(true);
        Debug.Log("settingGame");
    }
    void menugame(){
        
         settingwindow.SetActive(false);
          menuwindow.SetActive(true);
        
    }
}
