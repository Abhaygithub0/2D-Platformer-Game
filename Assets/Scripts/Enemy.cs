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
        Vector2 Point = currentPosition.position - transform.position;

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
