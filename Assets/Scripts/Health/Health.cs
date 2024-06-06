using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [Header ("Health")]
   [SerializeField] private float startingHealth;
   public float currentHealth { get; private set; }      //changed to public so the healthbar script can access, added some constructer things to make sure cant be accessed from anywhere
   private Animator anim;
   private bool dead;

   /*[Header ("iFrames")]
   [SerializeField] private float iFramesDuration;
   [SerializeField] private int numberofFlashes;
   private SpriteRenderer spriteRend;*/


   private void Awake() {
       currentHealth = startingHealth;
       anim = GetComponent<Animator>();
       //spriteRend = GetComponent<SpriteRenderer>();
   }

   public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0) {
            //checking if player hurt
            anim.SetTrigger("hurt");
            //StartCoroutine(Invulnerability());
            //iframs
        }
        else {
            if (!dead){
            //player dead
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
   }

   public void AddHealth(float _value){
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
   }

   public void Respawn(){
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
   }

   /*private IEnumerator Invulnerability() {
        Physics2D.IgnoreLayerCollision();
   }*/

   /*private void Update() {
        if (Input.GetKeyDown(KeyCode.E)){
            TakeDamage(1);
        }
   }*/
}
