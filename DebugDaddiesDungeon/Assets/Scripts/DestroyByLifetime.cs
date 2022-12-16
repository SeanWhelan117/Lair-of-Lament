using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLifetime : MonoBehaviour
{
    public float lifetime;

    //destroys items from the hierarchy
    /// <summary>
    /// Dsetroys an object via the lifetime of the object.
    /// </summary>
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
