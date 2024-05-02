using System;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;
    
    private Vector2 initialBoxSize;
    private Vector2 initialBoxOffset;
public int speedi;
public int jumpvalue;

private bool isJumptrue;
public Transform groundcheck;
public LayerMask layers;
public float groundcheckradius;

 void Start()
 {
        initialBoxSize = boxCollider2D.size;
        initialBoxOffset = boxCollider2D.offset;
         
 }
    private void Update()
    {
isJumptrue = Physics2D.OverlapCircle(groundcheck.position,groundcheckradius,layers);

         float horizontalInput = Input.GetAxisRaw("Horizontal");
       float verticalInput = Input.GetAxisRaw("Jump");
         playAnimation(horizontalInput,verticalInput);
         Movecharachter(horizontalInput,verticalInput);
    }

   private void Movecharachter(float horizontalInput , float verticalInput){
    Vector3 position = transform.position;
    position.x = position.x + horizontalInput*speedi*Time.deltaTime;
    transform.position = position;
     if (verticalInput>0 && isJumptrue){
        Debug.Log("hapining");
      /*  Vector3 posit = transform.position;
        position.y = position.y + verticalInput*jumpvalue*Time.deltaTime;
       transform.position = posit;*/
           GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpvalue, ForceMode2D.Impulse);
    }

   }

   private void playAnimation(float horizontalInput,float verticalInput)
{
 animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        

        Vector3 scale = transform.localScale;
        if (horizontalInput < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (horizontalInput > 0)
        {
            scale.x = 1 * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

      
        if (verticalInput>0 && isJumptrue){
            Debug.Log("working");
            animator.SetBool("IsJump",true);
        }
        else{
            animator.SetBool("IsJump",false);
        }

        if (Input.GetKey(KeyCode.LeftControl)){
        animator.SetBool("IsCrouch",true);
        Crouch(true);
        }
        else{
            animator.SetBool("IsCrouch",false);
            Crouch(false);
        }
}
    public void Crouch(bool crouch)
    {
       
        if (crouch==true)
        {
             animator.SetBool( "IsCrouch", crouch );
             float offX = 0.01648927f;     //Offset X
            float offY = 0.55f;      //Offset Y

            float sizeX = 0.5792472f;     //Size X
            float sizeY = 1f;     //Size Y

            boxCollider2D.size = new Vector2( sizeX, sizeY );  
            boxCollider2D.offset = new Vector2( offX, offY );   
           
        }
        else
        {
            boxCollider2D.size = initialBoxSize;
            boxCollider2D.offset = initialBoxOffset;
        }
    }

}


