using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Button : MonoBehaviour
{
    private bool canBeClicked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimateClick()
    {
        // Start position (resting)
        Transform buttonTransform = this.GetComponent<Transform>();
        Vector3 originalPosition = this.GetComponent<Transform>().position;
        Vector3 pressedOffset = buttonTransform.TransformDirection(new Vector3(-0.1f, 0.0f, 0.0f));
        Vector3 pressedPosition = originalPosition + pressedOffset;
        float animationDuration = 0.2f; // Total time for pressing and releasing
        float elapsedTime = 0f;

        // Press down
        while (elapsedTime < animationDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / (animationDuration / 2);
            this.GetComponent<Transform>().position = Vector3.Lerp(originalPosition, pressedPosition, t);
            yield return null;
        }
        this.GetComponent<Transform>().position = pressedPosition; // Ensure it's at the end position

        // button come back up
        elapsedTime = 0f;
        while (elapsedTime < animationDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / (animationDuration / 2);
            this.GetComponent<Transform>().position = Vector3.Lerp(pressedPosition, originalPosition, t);
            yield return null;
        }
        this.GetComponent<Transform>().position = originalPosition; // Ensure it's back to the original position

        ClickedButton();
        canBeClicked = true;
    }

    void Interacted()
    {
        if (canBeClicked)
        {
            canBeClicked = false;
            StartCoroutine("AnimateClick");
        }
    }

    [Header("Debug")]
    public bool ButtonClickedText;
    [Header("Button call Parameters")]
    public string[] FunctionToCall;
    public GameObject[] ObjectToCall;
    void ClickedButton()
    {
        for (int i = 0; i < ObjectToCall.Length; i++)
        {
            if (ObjectToCall[i] != null && FunctionToCall[i] != null)
            {

                ObjectToCall[i].BroadcastMessage(FunctionToCall[i]);
                if (ButtonClickedText)
                    print("Button clicked");
            }
        }
    }
}
