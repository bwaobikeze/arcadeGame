using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackscript : MonoBehaviour
{
   
    public Animator Anim;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0)){
        Attack();
        }
          if(Input.GetKeyDown(KeyCode.Mouse1)){
        Attack();
        }
        
    }
    void Attack(){
        Anim.SetTrigger("attack");
        Anim.SetTrigger("Secondattack");


    }
}
