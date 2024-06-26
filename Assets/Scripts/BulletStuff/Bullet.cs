using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    /// Robert Longenbach
    /// This script is for the bullets that the enemies shoot. 
    /// 5-5-24
    public float bulletLife = 1f;
    public float rotation = 0f;
    public float speed = 1f;
    public int damage;

    private Vector2 spawnPoint;
    private float timer = 0f;

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<PlayerController>())
        {
            var playerController = other.GetComponent<PlayerController>();
            playerController.TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }
}
