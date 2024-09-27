// this abstraction will be used for cursor highlighting and similar!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    void ClickedCursor()
    {
        this.SendMessage("Interacted");
    }
}
