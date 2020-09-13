using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackscript : MonoBehaviour
{
   //Variables for The duration of the attack
    public Animator Anim;
    public float attackTime;
    public float startTimeAttack;
// the variables for the location of the attack
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemeis;
      Collider2D[] damage;

    // Update is called once per frame
     void Start() {
         Anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        
        if(Input.GetButton("Fire1")){
        Attack();
        }

    }
    void Attack(){
        //Anim.SetTrigger("attack");
        //Anim.SetTrigger("Secondattack");
         if(attackTime<=0){
         Anim.SetBool("Attack",true);
         Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemeis);
         for(int i =0; i < damage.Length; i++){

             Destroy(damage[i].gameObject);
         }
            attackTime=startTimeAttack;
        }else{
            attackTime -= Time.deltaTime;
            Anim.SetBool("Attack",false);
        }


    }
      private void OnDrawGizmosSelected() {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(attackLocation.position, attackRange);
         
     }
}
// attackTime 0, StartTimeATTack 0.3, Attack Location AttackLocation gameobject
//Attack Range 0.19, Enemeis Layers
