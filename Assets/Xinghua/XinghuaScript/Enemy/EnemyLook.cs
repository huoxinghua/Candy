using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    [SerializeField] private Material _material;
    private Renderer render;
    private void Start()
    {
        render = gameObject.GetComponent<Renderer>();

    }
    public void ChangeCloth()
    {
        Debug.Log("change enemy look");
     
       render.material = _material;    
    }
    private void Update()
    {
        ChangeCloth();
    }
}
