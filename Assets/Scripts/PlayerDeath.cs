using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Animator animator;

private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.GetComponent<PlayerController>() != null){
        playdeathanimation();
        Debug.Log("player died");
    }
}
 private void playdeathanimation(){
     if (animator != null)
        {
            animator.SetTrigger("isDied"); // Trigger the "Death" animation
        }
        else
        {
            Debug.LogError("Animator component not found on player!");
        }
 }
}
