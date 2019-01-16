using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitTrigger : MonoBehaviour
{
    [SerializeField] int playerDamageReceived = 1;
    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            playerHealth.SubtractPlayerHealth(playerDamageReceived);
        }
    }
}
