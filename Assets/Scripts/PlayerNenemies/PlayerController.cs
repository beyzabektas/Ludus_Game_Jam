using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool face = true;
    public float speed;
    public Animator animator;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);
        transform.position += direction * speed * Time.deltaTime;
        if(horizontal > 0 && face == false)
        {
            turn();
        }

        else if (horizontal < 0 && face == true)
        {
            turn();
        }

        else if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
            StartCoroutine(StopAttackAnimation());
        }

    }

    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                //animator.SetFloat("horizontal", direction.x);
                //animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving",false);
            }
        }
    }

    IEnumerator StopAttackAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("isAttacking", false);
    }
    void turn()
    {
        face = !face;
        Vector2 yeniScale = transform.localScale;
        yeniScale.x *= -1;
        transform.localScale = yeniScale;
    }
}