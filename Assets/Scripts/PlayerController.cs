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
    public float speed;
    private Rigidbody rb;
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
        playerMove();
    }

    /// <summary>
    /// Gets WASD Input from the Player and applies corresponding velocity to the rigidbody
    /// </summary>
    private void playerMove()
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
}
