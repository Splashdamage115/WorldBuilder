using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeverPulled : MonoBehaviour
{
    public float maxUpwardRotation;
    private bool canBePulled;
    private bool isPulled;
    private Transform LeverTransform;
    float currentRotation;

    [Header("Debug")]
    public bool LeverPulledText;
    [Header("Lever Pull call Parameters")]
    public string[] FunctionToCall;
    public GameObject[] ObjectToCall;

    private void Start()
    {
        canBePulled = true;
        isPulled = false;
        LeverTransform = GetComponent<Transform>();
        currentRotation = maxUpwardRotation;
    }

    IEnumerator AnimateRotation()
    {
        float flip = 1.0f;
        if (isPulled) { flip = -1.0f; }

        for (int i = 0; i < 90; i++)
        {
            
            currentRotation -= flip;
            currentRotation = Mathf.Clamp(currentRotation, 0.0f, maxUpwardRotation);
            LeverTransform.rotation = Quaternion.Euler(LeverTransform.rotation.x, LeverTransform.rotation.y, currentRotation);
            yield return new WaitForEndOfFrame();
        }
        if (!isPulled)
        {
            LeverPullFinished();
            isPulled = true;
        }
        else
        {
            LeverUnPulled();
            isPulled = false;
        }

        canBePulled = true;
        yield return null;
    }

    void Interacted()
    {
        if (canBePulled)
        {
            canBePulled = false;
            StartCoroutine("AnimateRotation");
        }
    }

    void LeverPullFinished()
    {
        callFunctions(true);
    }

    void LeverUnPulled()
    {
        callFunctions(false);
    }

    void callFunctions(bool pulled)
    {
        for (int i = 0; i < ObjectToCall.Length; i++)
        {
            if (ObjectToCall[i] != null && FunctionToCall[i] != null)
            {
                ObjectToCall[i].BroadcastMessage(FunctionToCall[i], pulled);
            }
        }
        if (LeverPulledText)
        {
            if (pulled)
                print("Lever Pulled");
            else
                print("Lever UnPulled");
        }
    }
}
