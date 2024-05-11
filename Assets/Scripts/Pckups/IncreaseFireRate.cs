/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Raises the Player's fire rate by 25%
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFireRate : MonoBehaviour
{
    public PlayerController playerController;

    /// <summary>
    /// decreases cooldown between player's shots
    /// </summary>
    public void FireRateUp()
    {
        playerController = gameObject.GetComponent<Pickup>().playerController;

        playerController.fireRate *= 0.8f;
    }
}
