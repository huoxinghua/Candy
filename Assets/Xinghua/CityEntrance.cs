using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class CityEntrance : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f;
    private Enemy enemy;
    [SerializeField] private int pushThreshold = 10;
    private int pushCount = 0; 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enemy is pushing the door");
        if (other.gameObject.GetComponent<Enemy>())
        {
            Interact();
        }
        enemy = other.gameObject.GetComponent<Enemy>();
    }
    public void Interact()
    {

        pushCount++;
        Debug.Log($"enemy is pushing the door. Push count: {pushCount}");
        if (pushCount >= pushThreshold)
        {
            OpenDoor();
        } 
    }

    private void OpenDoor()
    {
        Rigidbody doorRb = gameObject.AddComponent<Rigidbody>();
        if (doorRb != null)
        {
            Vector3 pushDirection = transform.position - enemy.transform.position;
            pushDirection.y = 0;

            doorRb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);
        }
    }
  
}
