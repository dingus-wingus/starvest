/*
 * Author: Sean Gibson
 * Last Updated: 4/30/24
 * Controls Player Movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Vars
    public float speed;
    private Rigidbody rb;

    //Shooting Vars
    public GameObject bulletPrefab;
    private bool canShoot = true;

    public float fireRate;
    public float range;
    public float bulletSpeed;
    public int damage;

    private int bulletsShot = 0;

    private MeshRenderer mesh;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerShoot();
    }

    /// <summary>
    /// Gets WASD Input from the Player and applies corresponding velocity to the rigidbody
    /// </summary>
    private void PlayerMove()
    {
        var velocityVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocityVector.y += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocityVector.y -= speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocityVector.x += speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocityVector.x -= speed;
        }

        rb.velocity = velocityVector;
    }

    /// <summary>
    /// Returns a Vector3 with the direction of whichever arrow key is pressed
    /// </summary>
    /// <returns></returns>
    private Vector3 GetArrowKeyVector()
    {
        var arrowKeyVector = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            arrowKeyVector.x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            arrowKeyVector.x = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            arrowKeyVector.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            arrowKeyVector.y = -1;
        }

        return arrowKeyVector;
    }

    /// <summary>
    /// Spawns Bullets while the player is holding any of the arrow keys
    /// </summary>
    private void PlayerShoot()
    {
        var shootVector = GetArrowKeyVector();
        if (shootVector != Vector3.zero && canShoot == true)
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            PlayerBullet newBulletScript = newBullet.GetComponent<PlayerBullet>();

            newBullet.transform.position = transform.position + shootVector;

            newBulletScript.direction = shootVector;
            newBulletScript.speed = bulletSpeed;
            newBulletScript.damage = damage;
            newBulletScript.range = range;

            canShoot = false;
            StartCoroutine("StartShotCooldown");
        }
    }

    private IEnumerator StartShotCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
