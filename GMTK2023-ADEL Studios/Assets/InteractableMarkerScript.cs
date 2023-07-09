using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMarkerScript : MonoBehaviour
{

    [SerializeField] private Interactable[] interactableObjects;
    [SerializeField] private Camera _cam;

    void Start()
    {
        interactableObjects = FindObjectsByType<Interactable>(FindObjectsSortMode.None);
        _cam = GetComponent<Camera>();

        foreach (Interactable interactable in interactableObjects)
        {
            interactable.createImage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Interactable interactable in interactableObjects)
        {
            interactable.Img.transform.position = _cam.WorldToScreenPoint(interactable.transform.position);
        }
    }
}
