using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerFollow;
    Transform cameraPosition;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = GetComponent<Camera>().transform;
        offset = new Vector3(0.0f, 1.7f, 0.0f);
    }

    void LateUpdate()
    {
        cameraPosition.position = playerFollow.position + offset;
    }
}
