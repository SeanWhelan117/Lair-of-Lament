using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLifetime : MonoBehaviour
{
    public float lifetime;

    //destroys items from the hierarchy
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
