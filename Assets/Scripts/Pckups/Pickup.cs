/*
 * Author: Sean Gibson
 * Last Updated 5/10/24
 * On contact with the player, destroys self and invokes the given function
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    public UnityEvent onPickupFunction;
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            playerController = other.GetComponent<PlayerController>();

            onPickupFunction.Invoke();

            Destroy(gameObject);
        }
    }
}
