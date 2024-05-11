/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Gives a GameObject Health, Blinks the mesh once when taking damage, and invokes onHealthDepleted when health reaches 0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TakeDamageFromBullet : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth = 1;

    public MeshRenderer mesh;

    public UnityEvent onHealthDepleted;

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
    /// blinks the mesh once
    /// </summary>
    /// <returns></returns>
    private IEnumerator Blink()
    {
        mesh.enabled = false;
        yield return new WaitForSeconds(0.05f);
        mesh.enabled = true;
    }

    /// <summary>
    /// applies int damage to the object's health, if health <= 0, invokes onHealthDepleted
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine("Blink");
        if (currentHealth <= 0)
        {
            onHealthDepleted.Invoke();
        }
    }
}
