using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;
    public float walkSpeed = 9;

    public Rigidbody rb;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Moves the Player Left/Right based on A/D Input
    /// </summary>
    private void playerMove()
    {
        //Get Axis of Left/Right Input
        var velocityVector = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            velocityVector.x -= walkSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocityVector.x += walkSpeed;
        }

        velocityVector.y = rb.velocity.y;
        rb.velocity = velocityVector;
    }
}
