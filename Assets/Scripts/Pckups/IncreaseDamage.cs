/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Raises the Player's damage by 1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    public PlayerController playerController;

    /// <summary>
    /// raises player's damage
    /// </summary>
    public void DamageUp()
    {
        playerController = gameObject.GetComponent<Pickup>().playerController;

        playerController.damage += 1;
    }
}
