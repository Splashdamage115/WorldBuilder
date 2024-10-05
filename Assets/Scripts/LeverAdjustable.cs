using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LeverAdjustable : MonoBehaviour
{
    public float maxUpwardRotation;
    private Transform LeverTransform;
    public Transform followPoint;

    [Header("Debug")]
    public bool LeverPulledText;
    [Header("Lever Pull call Parameters")]
    public string[] FunctionToCall;
    public GameObject[] ObjectToCall;

    private void Start()
    {
        LeverTransform = GetComponent<Transform>();
    }

    void Update()
    {

        // Determine which direction to rotate towards
        Vector3 targetDirection = followPoint.position - LeverTransform.position;

        // The step size is equal to speed times frame time.
        float singleStep = 1.0f * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
