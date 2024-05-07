using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Vars")]
    public float speed = 4;
    private Rigidbody rb;
    private Vector3 velocityVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        int rand = Random.Range(1, 4);

        if (rand<2)
        {
            velocityVector.x += speed / 2;
        }
        else
        {
            velocityVector.x -= speed / 2;
        }

        if (rand % 2 == 0)
        {
            velocityVector.y += speed / 2;
        }
        else
        {
            velocityVector.y -= speed / 2;
        }

        rb.velocity = velocityVector;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "hWall")
        {
            velocityVector.y *= -1;
        }

        if (collision.collider.tag == "vWall")
        {
            velocityVector.x *= -1;
        }

        if (collision.collider.GetComponent<PlayerController>())
        {
            velocityVector *= -1;
            collision.collider.GetComponent<PlayerController>().TakeDamage(1);
        }

        rb.velocity = velocityVector;
    }
}
