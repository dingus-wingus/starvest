/*
 * Author: Sean Gibson
 * Last Updated: 5/2/24
 * Gives an object health that is decreased by PlayerBullets
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TakeDamageFromBullet : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth = 1;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Applies damage to the enemy's health
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destroys Self
    /// </summary>
    void Die()
    {
        Destroy(this.gameObject);
    }

}
