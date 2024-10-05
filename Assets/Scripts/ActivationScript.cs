using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    void Activate()
    {
        ParticleSystem p = GetComponent<ParticleSystem>();
        if (p.isStopped)
        {
            p.Play();
        }
        else
        {
            p.Stop();
        }
    }
}
