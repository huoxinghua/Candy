using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveDoor : MonoBehaviour,IInteractable
{
    private Vector3 closedPosition;
    protected Vector3 targetPosition;
    [SerializeField] Vector3 offsetPosition;

    private void Start()
    {
        closedPosition = transform.position;
    }

    public virtual void Interact()
    {
        // Set the target position relative to the closed position
        targetPosition = closedPosition + offsetPosition;
        StartCoroutine(MoveDoorCoroutine(targetPosition));
    }

    protected IEnumerator MoveDoorCoroutine(Vector3 targetPosition)
    {
        float duration = 1.0f; // Duration of the movement
        float elapsedTime = 0f;
        // Store the starting position
        Vector3 startingPosition = transform.position; 

        while (elapsedTime < duration)
        {
            // Calculate the new position based on time
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            // Increment the elapsed time
            elapsedTime += Time.deltaTime; 
            yield return null; // Wait for the next frame
        }

        // Ensure the door is exactly at the target position
        transform.position = targetPosition;
    }
    public void ShowKeyToInteract()
    {

    }
}
