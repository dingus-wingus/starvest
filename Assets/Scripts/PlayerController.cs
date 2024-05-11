/*
 * Author: Sean Gibson
 * Last Updated: 5/10/24
 * Controls Player Movement, Shooting, Health
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Health Vars")]
    public int lives = 3;
    public int maxHealth = 3;
    public int currentHealth = 0;
    public bool invincible = false;
    public Health healthbar;
    public TMP_Text livesDisplay;

    public int deathSceneIndex;
    public Vector3 startPosition;

    [Header("Movement Vars")]
    public float speed;
    private Rigidbody rb;

    [Header("Shooting Vars")]
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
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        currentHealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerShoot();

    }

    /// <summary>
    /// Makes the player's mesh blink and turns them invincible for given seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    private IEnumerator DoInvincibleSeconds(float seconds)
    {
        invincible = true;
        for (int i = 0; i < seconds*10; i++)
        {
            if (i % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);

            GetComponent<MeshRenderer>().enabled = true;
        }

        invincible = false;
    }

    /// <summary>
    /// Respawns the Player
    /// </summary>
    private void Respawn()
    {
        transform.position = startPosition;
        currentHealth = maxHealth;
        StartCoroutine("DoInvincibleSeconds", 5);
        healthbar.SetHealth(currentHealth);

        livesDisplay.text = "Lives: " + lives.ToString();
    }

    /// <summary>
    /// Sends the Player to the Game Over Scene
    /// </summary>
    private void OnGameOver()
    {
        SceneManager.LoadScene(deathSceneIndex);
    }

    /// <summary>
    /// Applies Damage to the Player's health, and if health is depleted, subtracts a life and calls OnGameOver() or Respawn()
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        if (invincible == false)
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);


            if (currentHealth <= 0)
            {
                lives -= 1;


                if (lives <= 0)
                {
                    OnGameOver();
                }
                else
                {
                    Respawn();
                }
            }
            else
            {
                StartCoroutine("DoInvincibleSeconds", 3);
            }
        }
        healthbar.SetHealth(currentHealth);
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
            bulletsShot++;
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

    /// <summary>
    /// Does the cooldown for shooting
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartShotCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
