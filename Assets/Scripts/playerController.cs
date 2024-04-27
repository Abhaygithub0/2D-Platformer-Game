
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        float speedkivalue = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(speedkivalue));
        Vector3 scale = transform.localScale;
        if (speedkivalue < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (speedkivalue > 0)
        {
            scale.x = 1 * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("key pressed");
            bool isCrouching = animator.GetBool("IsCrouch");
            animator.SetBool("IsCrouch", ! isCrouching);
        }

 float jumpvalue = Input.GetAxisRaw("Vertical");
  animator.SetBool("IsJump", false);
      
        if (jumpvalue > 0)
        {
           animator.SetBool("IsJump", true);
        }
       
    }
}
