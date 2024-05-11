using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Vars")]
    public float speed = 4;
    public Rigidbody rb;
    private Vector3 velocityVector = Vector3.zero;

    [Header("Reward Parameters")]
    public int pointReward = 100;
    public int itemDropChance = 100;
    public List<GameObject> itemPrefabs;

    public bool dead = false;

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

    public void Die()
    {

        int itemDropCheck = Random.Range(1, 100);

        if (itemDropCheck <= itemDropChance)
        {
            int randomItemIndex = Random.Range(0, itemPrefabs.Count);

            GameObject newItem = Instantiate(itemPrefabs[randomItemIndex]);
            newItem.transform.position = transform.position;
        }

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "hWall")
        {
            velocityVector.y *= -1;
        }
        else if (collision.collider.tag == "vWall")
        {
            velocityVector.x *= -1;
        }
        else
        {
            velocityVector *= -1;
        }

        if (collision.collider.GetComponent<PlayerController>())
        {
            collision.collider.GetComponent<PlayerController>().TakeDamage(1);
        }

        rb.velocity = velocityVector;
    }
}
