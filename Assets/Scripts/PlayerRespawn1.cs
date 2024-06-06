using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn1 : MonoBehaviour
{
    private Transform currentCheckpoint; //to store locatoin of latest checkpoint
    private Health playerHealth; //need to restore health after respawn

    private void Awake() {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn() {
        transform.position = currentCheckpoint.position; //to move player to checkpt location

        //NEED TO: restore player health and animation
    }
}
