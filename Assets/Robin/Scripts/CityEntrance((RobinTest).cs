using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ProBuilder.Shapes;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject cameraAlarm;
    private bool isAlarmed;
    [SerializeField] private float pushForce = 10f;
    private AIEnemy enemy;
    [SerializeField] protected float pushThreshold = 6;
    [SerializeField] protected float pushCount = 0;

    private void Start()
    {
        isAlarmed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AIEnemy>())
        {
            Interact();
        }
        enemy = other.gameObject.GetComponent<AIEnemy>();
    }
    public void Interact()
    {

        pushCount++;
        // Debug.Log($"enemy is pushing the door. Push count: {pushCount}");
        if (pushCount >= 3 && pushCount <= pushThreshold)
        {
            if (!isAlarmed)
            {
                DoorAlarm();
                isAlarmed = true;
            }
            
        }

        else if (pushCount >= pushThreshold)
        {
            DoorBeenOpened();

        }
     
    }
    public void DoorAlarm()
    {
        // Debug.Log("Door is going to open");
        //CameraManager.Instance.AlarmCamera(cameraAlarm);
    }

    private void DoorBeenOpened()
    {
        Rigidbody doorRb = gameObject.GetComponent<Rigidbody>();
        if (doorRb == null)
        {
             doorRb = gameObject.AddComponent<Rigidbody>();
        }
        else if (doorRb != null)
        {
            Vector3 pushDirection = transform.position - enemy.transform.position;
            pushDirection.y = 0;

            doorRb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);
        }
        else { Debug.LogError("Failed to get or add Rigidbody to the door."); }
    }
  
}
