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
    public float restartDelay = 3f;

    
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
            SoundManager.Instance.play(soundplaces.Playerdeath);
            aniame.SetTrigger("IsDied");

            StartCoroutine(restartwithdelay(restartDelay));
            GetComponent<PlayerController>().enabled=false;
            GetComponent<Rigidbody2D>().simulated=false;
            GetComponent<Collider2D>().enabled=false;

            //restartgameafterfewsconds.
           

        
         
        }
    }


private IEnumerator restartwithdelay(float delay){
    yield return new WaitForSeconds(delay);
    gameouverUI.SetActive(true);
}
}

