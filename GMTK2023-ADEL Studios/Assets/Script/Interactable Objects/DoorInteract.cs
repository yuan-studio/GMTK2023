using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteract : Interactable
{
    [SerializeField] private GameObject doorModel;

    [SerializeField] private float openAmount = 5f;
    [SerializeField] private float openDuration = 1f;

    [SerializeField] private bool isOpen = false;
    private bool animating = false;

    private IEnumerator ToggleDoor()
    {
        animating = true;
        Vector3 startPosition = doorModel.transform.position;
        Vector3 targetPosition;
        if (isOpen)
        {
            targetPosition = startPosition - new Vector3(0f, openAmount, 0f);
        }
        else
        {
            targetPosition = startPosition + new Vector3(0f, openAmount, 0f);
        }
         

        float elapsedTime = 0f;

        while (elapsedTime < openDuration)
        {
            doorModel.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / openDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        doorModel.transform.position = targetPosition;
        animating = false;
    }



    public override void Interact()
    {
        if (!animating)
        {
            StartCoroutine(ToggleDoor());
            isOpen = !isOpen;
        }
    }
}
