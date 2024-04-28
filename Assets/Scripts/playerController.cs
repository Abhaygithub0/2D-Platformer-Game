using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private SpriteRenderer spr;

    private Vector2 initialBoxSize;
    private Vector2 initialBoxOffset;

    private Color colore;

    

 

 void Start()
 {
     initialBoxSize = boxCollider2D.size;
        initialBoxOffset = boxCollider2D.offset;
        colore = spr.color;
 }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)){
            spr.color=Color.blue;
        }
        else {
spr.color=colore;
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
          PlayJumpAnimation( verticalInput );

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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            
            Crouch(true);
        }
        else
        {
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

     public void PlayJumpAnimation( float vertical )
    {
        if ( vertical > 0 )
        {
            animator.SetTrigger( "IsJump" );
        }
    }
}


