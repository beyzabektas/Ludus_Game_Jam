using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.tag == "Enemy")
        {
            //other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
  

    //if (!other.TryGetComponent(out IDamagable damagable))
    //    return;

    //damagable.TakeDamage(damageToGive);
}
}