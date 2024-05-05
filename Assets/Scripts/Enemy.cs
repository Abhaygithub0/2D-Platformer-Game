using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rgbd2d;
  [SerializeField]  private Animator animator;
   [SerializeField] private SpriteRenderer sprender;
    private Transform currentPosition;

    public float speedofEnemy;

    [SerializeField]private GameObject pointA;
   [SerializeField] private GameObject pointB;
private void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPosition = pointB.transform;
        animator.SetBool("Iswalking" , true);
    }

    private void Update() 
    {
      
      enemymovement();
      
    }

private void OnCollisionEnter2D(Collision2D other) 
{
    if(other.gameObject.GetComponent<PlayerController>() != null){
        Debug.Log("Hit");
         PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
         if(playerHealth != null){
           playerHealth.takedamage(1);
         }
         else{
            Debug.Log("didnot find it");
         }
    
    }
}
    void enemymovement(){

         if (currentPosition == pointB.transform)
        {
            rgbd2d.velocity = new Vector2(speedofEnemy , 0);
            sprender.flipX =false;
        }

        else  {
            rgbd2d.velocity = new Vector2(-speedofEnemy , 0);
            sprender.flipX =true;
        }

      if (Vector2.Distance(transform.position,currentPosition.position)<0.5f && currentPosition == pointB.transform)
        {
            currentPosition = pointA.transform;
        }

        if (Vector2.Distance(transform.position,currentPosition.position)<0.5f && currentPosition == pointA.transform)
        {
            currentPosition = pointB.transform;
        } 
    }
}
