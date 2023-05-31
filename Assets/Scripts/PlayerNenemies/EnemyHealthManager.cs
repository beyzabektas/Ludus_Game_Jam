using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    private bool isEnemyDead = false;
    public float pickupDistance = 15f;

   // public GameObject uiObject;
    public GameObject Player;
  //  public GameObject portal;
    public GameObject nlootDrop;

   
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        nlootDrop.SetActive(false);
      //  portal.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Player.gameObject.tag == "Player")
        {
            nlootDrop.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        else
        {
            nlootDrop.SetActive(false);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        nlootDrop.SetActive(false);
    }


    void Update()
    {
        if (enemyCurrentHealth <= 0 && !isEnemyDead)
        {
            isEnemyDead = true;
            Destroy(gameObject);
          //  portal.SetActive(true);
            Instantiate(nlootDrop, transform.position, Quaternion.identity);



            if (Input.GetKeyDown(KeyCode.E))
            {
                
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, pickupDistance);

                if (hit.collider != null && hit.collider.CompareTag("Pickable"))
                {

                    Destroy(nlootDrop);
                  
                }
            }
            
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
}
