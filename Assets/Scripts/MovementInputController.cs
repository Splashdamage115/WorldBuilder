using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb; // player moveable body
    public float speed; // speed the player moves at
    private Vector3 move; // direction to move

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // after input move the player by the amount
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        move.x = movementVector.x;
        move.z = movementVector.y;
        move = rb.transform.TransformDirection(move);
        move.y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {
        // move player based on chosen move
        rb.AddForce((rb.transform.forward + move) * speed);
    }
}
