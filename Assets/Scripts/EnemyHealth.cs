using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider slider;

    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    private bool isEnemyDead = false;
   // public GameObject portal;


    void Start()
    {
        slider.maxValue = enemyMaxHealth;
        slider.value = enemyMaxHealth;
        enemyCurrentHealth = enemyMaxHealth;
     //   portal.SetActive(false);
    }

    
    void Update()
    {
        if (enemyCurrentHealth <= 0 && !isEnemyDead)
        {
            isEnemyDead = true;
           // portal.SetActive(true);
            Destroy(gameObject);
            
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;
        slider.value = enemyCurrentHealth;
       // Debug.Log("hasaarrrrrrrrr");
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }


}
