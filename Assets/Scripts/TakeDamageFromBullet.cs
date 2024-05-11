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

    private IEnumerator Blink()
    {
        mesh.enabled = false;
        yield return new WaitForSeconds(0.05f);
        mesh.enabled = true;
    }

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
