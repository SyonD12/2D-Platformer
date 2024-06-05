using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;
   public float currentHealth { get; private set; }      //changed to public so the healthbar script can access, added some constructer things to make sure cant be accessed from anywhere
   private Animator anim;

   private void Awake() {
       currentHealth = startingHealth;
       anim = GetComponent<Animator>();
   }

   public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0) {
            //checking if player hurt
            anim.SetTrigger("hurt");
        }
        else {
            //player dead
            anim.SetTrigger("die");
        }
   }

   /*private void Update() {
        if (Input.GetKeyDown(KeyCode.E)){
            TakeDamage(1);
        }
   }*/
}
