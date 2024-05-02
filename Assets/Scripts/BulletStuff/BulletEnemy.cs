using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float bulletLife = 1f;
    public float rotation = 0f;
    public float speed = 1f;

    private Vector2 spawnPoint;
    private float timer = 0f;

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (timer > bulletLife) Destroy(this.gameObject);

    }
}
