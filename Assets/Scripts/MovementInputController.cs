using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb; // player moveable body

    [Header("Movement")]
    public float speed; // speed the player moves at
    public Transform orientation;
    private Vector3 move; // direction to move
    [Range(0f, 10f)]
    public float interactRange;

    public Camera gameCam;

    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // after input move the player by the amount
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        //move.x = movementVector.x;
        //move.z = movementVector.y;
        //move = rb.transform.TransformDirection(move);
        
        move = orientation.forward * movementVector.y + orientation.right * movementVector.x;
        move.y = 0f;
    }

    void OnJump(InputValue _)
    {
        if (grounded)
        {
            grounded = false;
            rb.AddForce(new Vector3(0f, 500f, 0f), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            grounded = true;
    }


    void FixedUpdate()
    {
        // move player based on chosen move
        rb.AddForce(move.normalized * speed * 10f, ForceMode.Force);
    }

    void OnInteract(InputValue _)
    {
        RaycastHit hit;
        Ray ray = gameCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if(Vector3.Distance(transform.position, objectHit.position) <= interactRange)
                objectHit.SendMessage("ClickedCursor", null, SendMessageOptions.DontRequireReceiver);
        }
    }
}
