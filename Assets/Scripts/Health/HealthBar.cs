using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start() {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;    //is divided by ten bc that is the percentage of the image we are showing
    }
    private void Update(){
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
