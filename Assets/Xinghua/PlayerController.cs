using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   Rigidbody rb;
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
