using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    // Start is called before the first frame update
    bool grounded= false;
    public Transform groundCheck;
    public LayerMask groundlayer;
    float groundCheckRadius = 0.2f;
    public float jumpHeight;
    Animator myAnim;
    Rigidbody2D body;
    bool frontfacingDirection;
   public float PlayerSpeed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
          myAnim= GetComponent<Animator>();
          frontfacingDirection=true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


      // To check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("verticalSpeed", body.velocity.y);

        //player movement
          float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        body.velocity = new Vector2(move * PlayerSpeed, body.velocity.y);

          if (move > 0 && !frontfacingDirection)
        {
            flip();

        }
        else if (move < 0 && frontfacingDirection)
            flip();

    }
     void Update() {
       // jumping
      if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            body.AddForce(new Vector2(0, jumpHeight));

        }
    }


    void flip()
    {
        frontfacingDirection = !frontfacingDirection;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
}
