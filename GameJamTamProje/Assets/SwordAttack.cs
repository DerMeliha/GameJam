using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
  

    public Collider2D swordCollider;
    Vector2 rightAttackOffset;
    public float damage = 5;

    private void Start()
    {
        rightAttackOffset = transform.localPosition;
    }
    public void AttackRight()
    {
        print("attack right");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        print("attack left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x*-1,rightAttackOffset.y);    
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }

        if(other.tag == "Boss")
        {
            Boss boss = other.GetComponent<Boss>();

            if(boss != null)
            {
                boss.Health -= damage;
            }
        }
    }
}
