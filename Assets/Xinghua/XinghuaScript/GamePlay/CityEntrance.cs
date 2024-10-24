using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class CityEntrance : MoveDoor
{
    [SerializeField]private GameObject cameraAlarm;
    private bool isAlarmed;
    [SerializeField] private float pushForce = 10f;
    private AIEnemy enemy;
    [SerializeField] public float pushThreshold = 10;
    [SerializeField] public float currentPushThreshold ;
    [SerializeField] private float damageAmount = 0.03f;
    protected float pushCount = 0;
    [SerializeField] Image HPBar;
 
    private void Start()
    {
        isAlarmed = false;
        GameManager.Instance.currentPushThreshold = GameManager.Instance.pushThreshold;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AIEnemy>())
        {
            GameManager.Instance.currentPushThreshold -= GameManager.Instance.doorDamageAmount;
            HPBar.fillAmount = Mathf.Clamp(GameManager.Instance.currentPushThreshold / GameManager.Instance.pushThreshold, 0, 1);
            Debug.Log("pushThresholdLost is" + currentPushThreshold);
            Interact();
        }
        enemy = other.gameObject.GetComponent<AIEnemy>();
    }
    public override void Interact()
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

        else if (HPBar.fillAmount <= 0)
        {
            //DoorBeenOpened();
            StartCoroutine(MoveDoorCoroutine(targetPosition));
        }
        else 
        {
            Debug.Log("door is closed");
        }
     
    }
    public void DoorAlarm()
    {
        // Debug.Log("Door is going to open");
        CameraManager.Instance.AlarmCamera(cameraAlarm, true);
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
