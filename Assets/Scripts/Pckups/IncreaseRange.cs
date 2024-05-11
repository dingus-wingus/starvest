/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Raises the Player's range by 1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseRange : MonoBehaviour
{
    public PlayerController playerController;


    public void RangeUp()
    {
        playerController = gameObject.GetComponent<Pickup>().playerController;

        playerController.range += 1;
    }
}
