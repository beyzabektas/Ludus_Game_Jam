using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject Player;
    

    void Start()
    {
        uiObject.SetActive(false);
       
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        else
        {
            uiObject.SetActive(false);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        uiObject.SetActive(false);
    }
}
