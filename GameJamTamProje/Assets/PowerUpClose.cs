using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpClose : MonoBehaviour
{
    PowerUp powerUp;
    void OnTriggerEnter2D(Collider2D collision)
    {
        powerUp.powerUpUI.SetActive(false);
    }
}
