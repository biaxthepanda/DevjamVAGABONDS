using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public int cooldown;

    private void Start()
    {
        Invoke("DestroyThisObject",cooldown);
    }
    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
