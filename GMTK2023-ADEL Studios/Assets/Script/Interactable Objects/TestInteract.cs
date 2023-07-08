using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TestInteract : MonoBehaviour
{

    [SerializeField] public Interactable interactableObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.Interact();
        }
    }
}
