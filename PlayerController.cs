using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    Animator PlayerAnimator;
    bool facingRight = true;           //direction of the face(default right)

    public KeyCode keyToPress;
    public Transform groundCheckPosition;   //position of the circle that overlaps by ground to check if character is grounded or not.
    public float groundCheckRadius;         //raius of the circle that overlaps by ground to check if character is grounded or not.
    public LayerMask groundCheckLayer;      //layer of the circle that overlaps by ground to check if character is grounded or not.

    [SerializeField]
    bool isGrounded = false;                //checks if the player is grounded or not according to the values that are indicated.
    [SerializeField]
    private float movespeed=5f;
    [SerializeField]
    private float jumpSpeed=1f;
    [SerializeField]
    private float jumpFrequency=1f, nextJumpTime;
    [SerializeField]
    bool isJumped = false;
    public NoteObject noteObject;
    public GameObject perfectEffect,misseffect;
    public bool son;


    void Start()
    {

      


        PlayerAnimator = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody2D>();

 




    }

    void Update()
    {
        bool counter = NoteObject.canBePressed;

       bool counter2=NoteObject.kral;
        if (Input.GetKeyDown(keyToPress))
        {
            
            if  (Input.GetAxis("Vertical") > 0 && isGrounded && counter && nextJumpTime < Time.timeSinceLevelLoad && counter2)
            {
                
                Instantiate(perfectEffect, transform.position , perfectEffect.transform.rotation);
                GameManager.instance.PerfectHit();
            }
        }
       // if (Input.GetKeyDown(keyToPress)&&!counter2)
       // {
          //  Instantiate(misseffect, transform.position, misseffect.transform.rotation);

       // }
        
        HorizontalMove();   // horizontal move method, (player running)
        OnGroundCheck();    // is Player grounded or not?
        if(PlayerRB.velocity.x < 0 && facingRight)  // player is moving left but face is right, then flip direciton
        {
            flipDirection(); //flip direction

        }
        else if(PlayerRB.velocity.x > 0 && !facingRight)    // player is moving right but face is left, then flip direciton
        {
            flipDirection(); //flip direction
        }
        //&& (nextJumpTime < Time.timeSinceLevelLoad)
        if (Input.GetAxis("Vertical") > 0 && isGrounded && counter&&nextJumpTime < Time.timeSinceLevelLoad)   //if Vertical button(up key or "W" button) is pressed on keyboard and the character is on the ground and if she didn't jump once in 1 second, Jump.
        {
             GameManager.instance.NoteHit();
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency; //limits multiple jumping by once at a second.
            Jump();
            isJumped = true;        //the player has jumped by pressing the jump key so that the Jumping animation should be played. Otherwise, like falling from a height don't play the jumping animation.
        }
    }


    void HorizontalMove()   
    {
        PlayerRB.velocity = new Vector2(Input.GetAxis("Horizontal")* movespeed, PlayerRB.velocity.y);   // whenever right button("D" button) or left button("A" button) is pressed on keyboard, move the player according to the speed that is indicated.
        PlayerAnimator.SetFloat("playerSpeed", Mathf.Abs(PlayerRB.velocity.x)); // set playerSpeed value as player's current speed's absolute value so that if player moves swap to running animation from idle animation.
    }

    void flipDirection()    
    {
        facingRight = !facingRight;                     //set face direction value to opposite (true/false)
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;                         //flip the character
        transform.localScale = tempLocalScale;          //set as current status
    }

    void Jump()
    {
        PlayerRB.AddForce(new Vector2(0f, jumpSpeed));  //apply force in "Y" axis as jumpSpeed to jump.
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer); // creates a small circle and checks if that circle overlaps with the ground if it does then character is grounded so she can jump again.
        PlayerAnimator.SetBool("isGroundedAnim", isGrounded);   //set isGroundedAnim bool in the Animation section as same as the isGrounded bool to play animations.
        PlayerAnimator.SetBool("isPlayerJumped", isJumped);     //set the isPlayerJumped bool in the Animation section as same as the isJumped bool to play jump Animation.
        isJumped = false;
    }

}
