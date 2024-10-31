using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollect : MonoBehaviour
{
    public UnityEvent CameraTrigger;
    protected string  itemName;
    public AudioClip collectedSound;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null )
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            gameObject.SetActive(false);
            //add collect sound here
            if (collectedSound != null)
            {
                audioSource.PlayOneShot(collectedSound);
            }
           
           if (GameManager.Instance != null)
            {
                Inventory.Instance.AddItem(itemName, 1);
            }
            else
            {
                Debug.LogError("GameManager.Instance is null! GameManager is not initialized.");
            }
           // CameraTrigger?.Invoke();
        }

    }

}
