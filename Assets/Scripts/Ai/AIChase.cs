using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float yatayhareket;
    public int harekethizi;
    public float speed;

    public GameObject player;

    public bool faceright = true;
    public bool karakteryerde = true;

    private float distance;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yatayhareket = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(yatayhareket* harekethizi * 100* Time.deltaTime, rb.velocity.y);



        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.y = 0f;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (yatayhareket>0 && faceright ==false )
        {
            turn();
        }
        if (yatayhareket < 0 && faceright == true)
        {
            turn();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            karakteryerde = true;
        }
    }


    void turn()
    {
        faceright = !faceright;
        Vector2 yeniscale = transform.localScale;
        yeniscale.x *= -1;
        transform.localScale = yeniscale;
    }

}


