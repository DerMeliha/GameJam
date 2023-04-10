using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject chestClosed, chestOpen;
    public SwordAttack swordAttack;
    public PowerUp powerUp;


    void Start()
    {
        chestClosed.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        chestClosed.SetActive(false);
        chestOpen.SetActive(true);
        swordAttack.damage += 5;
        powerUp.powerUpOpen();
    }

}
