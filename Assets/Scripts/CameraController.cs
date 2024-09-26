using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerFollow;
    Transform cameraPosition;
    private Vector3 camRotation;

    Vector3 offset;
    [Range(50, 500)]
    public int sensitivity = 200;
    [Range(-45, -15)]
    public int minAngle = -30;
    [Range(30, 80)]
    public int maxAngle = 45;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = GetComponent<Camera>().transform;
        offset = new Vector3(0.0f, 1.7f, 0.0f);
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        cameraPosition.Rotate(Vector3.up * sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime);

        camRotation.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        camRotation.x = Mathf.Clamp(camRotation.x, minAngle, maxAngle);

        cameraPosition.localEulerAngles = new Vector3(camRotation.x, cameraPosition.localEulerAngles.y, 0);
        playerFollow.rotation = cameraPosition.rotation;
    }

    void LateUpdate()
    {
        cameraPosition.position = playerFollow.position + offset;
    }
}
