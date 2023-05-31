using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTansition2to3 : MonoBehaviour
{
    private void OnEnable()
    {
        FindObjectOfType<Enemy>().OnDeadAction += Execute;
    }

    private void OnDisable()
    {
        Enemy _enemy = FindObjectOfType<Enemy>();

        if (_enemy)
            _enemy.OnDeadAction -= Execute;
    }

    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }
    private void Execute()
    {
        //Observer Design Pattern

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
