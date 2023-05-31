using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public Slider slider;
    public int playerMaxHealth;
    public int playerCurrentHealth;
    private bool isPlayerDead = false;


    public Text dieText;

    private SpriteRenderer sprite;
    public GameObject weapon;
  

    void Start()
    {


        if (slider)
        {
            slider.maxValue = playerMaxHealth;
            slider.value = playerMaxHealth;
        }
        playerCurrentHealth = playerMaxHealth;
        sprite = GetComponent<SpriteRenderer>();

        dieText.text = "";

    }

    
    void Update()
    {
        if (playerCurrentHealth <= 0 && !isPlayerDead)
        {
            isPlayerDead = true;
            weapon.SetActive(false);
            sprite.enabled = false;
            dieText.text = "ÖLDÜN";
            dieText.gameObject.SetActive(true);
            StartCoroutine(HideMessageAfterDelay(3.0f));

        }

        if (playerCurrentHealth > 0 && dieText.gameObject.activeSelf == true)
        {
            dieText.gameObject.SetActive(false);
        }
    }

    IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dieText.gameObject.SetActive(false);
        isPlayerDead = false; // false burda olacak biraz sahnede kalmasý için
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        slider.value = playerCurrentHealth;
    }
    public void SetMaxHealth()
    {

        playerCurrentHealth = playerMaxHealth;

    }
}
