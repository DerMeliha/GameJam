using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    Animator _anim;
    public int _currentHealth;

    public Healthbar healthBar;
    PlayerController playerControl;
    public GameOver gameOver;
    private void Start()
    {
        _currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        gameOver.gameOver();
        _anim.SetBool("isDeath", true);
        playerControl.moveSpeed = 0f;
    }

}
