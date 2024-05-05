using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
     [SerializeField] Image healthbar;
     [SerializeField] Animator aniame;
     [SerializeField] GameObject gameouverUI;
 
    [SerializeField] private float health ;
   private float currenthealth;

     private void Awake() {
        currenthealth = health;
    }
     private void Start() {
       currenthealth = health;
    }

    private void Update() {
        healthbar.fillAmount = currenthealth/10;

       
    }

   public void takedamage(float damage){
        currenthealth = Mathf.Max(currenthealth - damage,0);
        health = currenthealth;

        if (health<=0){
            aniame.SetTrigger("IsDied");
            gameouverUI.SetActive(true);
            GetComponent<PlayerController>().enabled=false;
            //restartgameafterfewsconds.
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
         
        }
    }



}
