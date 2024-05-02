/*
 * Author: Sean Gibson
 * Last Updated: 4/30/24
 * Moves a projectile in given direction, holds damage value, despawns projectile after given despawnTime
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerBullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float range;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DespawnTimer(despawnTime));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        range -= speed * Time.deltaTime;
        if (range <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        var other = collision.collider;

        /* Deals damage to destructible objects. Dependant on Class TakeDamageFromBullet
        if (other.gameObject.GetComponent<TakeDamageFromBullet>())
        {
            var objectToDamage = other.gameObject.GetComponent<TakeDamageFromBullet>();

            objectToDamage.currentHealth -= damage;
        }
        */
        if (!other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
        }
    }
}