using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PickableItems : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
   {
     
    if(other.gameObject.GetComponent<PlayerController>() != null){
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        pc.scoreUpdate();
    
       Destroy(gameObject);
}

   }
}
