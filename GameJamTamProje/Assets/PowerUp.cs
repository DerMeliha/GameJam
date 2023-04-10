using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpUI;
    public void powerUpOpen()
    {
        powerUpUI.SetActive(true);
    }
}
