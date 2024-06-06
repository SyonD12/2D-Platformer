using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
     [SerializeField] private float damage;
     [SerializeField] private float movementDistance;
     [SerializeField] private float speed;
     private bool movingLeft;
     private float leftEdge;
     private float rightEdge;

     private void Awake() {
        leftEdge = transform.position.x - movementDistance;      //this code sets the area which teh player can move around
        rightEdge = transform.position.x + movementDistance;
     }

     private void Update() {
        if (movingLeft) {
            if (transform.position.x > leftEdge) {     //checking if is before left edge, if after left edge, not allowed to move
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);   //moving x val in negative direction based on speed times time spent moving, y and z coord stay the same
            } else {
                movingLeft = false;
            }
        }
        else {
            if (transform.position.x < rightEdge) {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else {
                movingLeft = true;
            }
        }
     }

     private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            collision.GetComponent<Health>().TakeDamage(damage);
        }
     }
}
