using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
   
   [SerializeField] GameObject gameoverUI2;

  
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.GetComponent<PlayerController>() != null)
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.SetCurrentLevelComplete();
            gameoverUI2.SetActive(true);
        }
        else
        {
            Debug.LogError("LevelManager instance is null!");
        }
    }
}
}
