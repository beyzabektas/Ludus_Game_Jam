using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript2 : MonoBehaviour
{
    public Text scoreText;
    private int scoreNum;
    public float pickupDistance = 15f;



    void Start()
    {
        scoreNum = 1;

        if (scoreText)
            scoreText.text = " " + scoreNum;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, pickupDistance);

            if (hit.collider != null && hit.collider.CompareTag("Pickable"))
            {

                Destroy(hit.collider.gameObject);
                scoreNum += 1;
                scoreText.text = " " + scoreNum.ToString();
            }
        }
    }


}
