using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMassage : MonoBehaviour
{
   
    public GameObject Canvas; // Canvas nesnesinin referansı

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Canvas'i etkinleştir
            Canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Canvas'i devre dışı bırak
            Canvas.SetActive(false);
        }
    }
}
