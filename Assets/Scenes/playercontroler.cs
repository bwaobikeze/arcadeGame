﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    // Start is called before the first frame update
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


    void flip()
    {
        frontfacingDirection = !frontfacingDirection;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
}
