using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public Image[] ehearts;
    public int ehealth = 5;
    int emaxHealth = 5;
    public void Damage(int amount)
    { // hasar alma
        ehearts[ehealth - 1].enabled = false; 
        ehealth -= amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // ehealth -= amount;
        }

    }
        void Update()
        {
            if (ehealth > emaxHealth)
            {
                ehealth = emaxHealth;
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                if (ehealth > 0)
                {
                    Damage(1);
                }
            }

        }
   
}
