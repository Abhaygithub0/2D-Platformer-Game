using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    
    

    private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.GetComponent<PlayerController>() != null){
        
      // PlayerController playerController =other.gameObject.GetComponent<PlayerController>();
      // playerController.PlaydieAnimation();
      int  sceneno = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneno);
    }
}

}
