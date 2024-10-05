using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    void Activate(bool activate = true)
    {
        ParticleSystem p = GetComponent<ParticleSystem>();
        if (p.isStopped || activate)
        {
            p.Play();
        }
        else
        {
            p.Stop();
        }
    }
}
