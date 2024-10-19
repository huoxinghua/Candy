using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ProBuilder.Shapes;

public class CityEntrance : MonoBehaviour
{
    [SerializeField] private float pushForce = 10f;
    private Enemy enemy;
    [SerializeField] private int pushThreshold = 10;
    private int pushCount = 0;
    public UnityEvent CameraTrigger;
    private void OnTriggerEnter(Collider other)
    {
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
        if (pushCount >= pushThreshold - 3 && pushCount <= pushThreshold)
        { 
            DoorAlarm();
            CameraTrigger?.Invoke();
        }

        else if (pushCount >= pushThreshold)
        {
            OpenDoor();
        } 
    }
    public void DoorAlarm()
    {
       
        {
            Debug.Log("Door is going to open");
            //tranfer the cam view
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
