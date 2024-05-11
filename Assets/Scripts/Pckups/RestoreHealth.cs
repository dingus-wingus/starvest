/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Heals the Player by the given healAmount
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour
{
    public PlayerController playerController;
    public int healAmount = 10;


    public void HealPlayer()
    {
        playerController = gameObject.GetComponent<Pickup>().playerController;

        playerController.currentHealth += healAmount;
        if (playerController.currentHealth > playerController.maxHealth)
        {
            playerController.currentHealth = playerController.maxHealth;
        }
        playerController.healthbar.SetHealth(playerController.currentHealth);
    }
}
