using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator animator;
    public float health = 10;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }


    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }
}
