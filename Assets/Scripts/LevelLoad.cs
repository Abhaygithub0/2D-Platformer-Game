using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] private string scene;
   

    private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.GetComponent<PlayerController>() != null)
    //if(other.gameObject.CompareTag("Player"))
    {
        SceneManager.LoadScene(scene);
        
    }
 }
    
}
