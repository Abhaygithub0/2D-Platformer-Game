using System;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreManager scoreManager;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;
    
    private Vector2 initialBoxSize;
    private Vector2 initialBoxOffset;
public int speedvalue;
public int jumpvalue;

private bool isJumptrue;
private bool isJumping;
public Transform groundcheck;
public LayerMask layers;
public float groundcheckradius;
 internal object playdeathanimation;

 //private Rigidbody2D rgbd2d;

    void Start()
 {
        initialBoxSize = boxCollider2D.size;
        initialBoxOffset = boxCollider2D.offset;
       // rgbd2d=GetComponent<Rigidbody2D>();
         
 }
    private void Update()
    {
   isJumptrue = Physics2D.OverlapCircle(groundcheck.position,groundcheckradius,layers);

         float horizontalInput = Input.GetAxisRaw("Horizontal");
         bool verticalInput = Input.GetButtonDown("Jump");
         playAnimation(horizontalInput);
         Movecharachter(horizontalInput ,verticalInput);
    }

   private void Movecharachter(float horizontalInput ,bool verticalInput){
    Vector3 position = transform.position;
    position.x = position.x + horizontalInput*speedvalue*Time.deltaTime;
    transform.position = position;
   
     if (verticalInput&& isJumptrue){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpvalue, ForceMode2D.Impulse);
        isJumping=true;
        SoundManager.Instance.play(soundplaces.Playerjump);
    }

   }

   private void playAnimation(float horizontalInput)
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
animator.SetBool("IsJump",isJumping&& !isJumptrue);

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

    public void scoreUpdate()
    {
       
        scoreManager.incrementvalue(10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isJumping = false;
        }
    }
}



