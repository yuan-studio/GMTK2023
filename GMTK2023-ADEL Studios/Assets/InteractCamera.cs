using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCamera : MonoBehaviour
{
    [SerializeField] private float interactRange = 8f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactRange, interactLayer))
            {
                if (hit.transform.GetComponent<Interactable>() is Interactable obj)
                {
                    obj.Interact();
                }
            }
        }
    }
}
