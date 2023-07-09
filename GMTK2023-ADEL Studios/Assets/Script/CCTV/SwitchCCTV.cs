using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCCTV : MonoBehaviour
{
    public Camera[] cameras;
    public Transform icon;
   
    public AudioSource audioSource;
    public AudioClip switchSound;
    private int currentCameraIndex = 0;

    void Start()
    {        
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
        {
            SwitchCamera(1);
            audioSource.PlayOneShot(switchSound);
        }
        else if (scroll < 0)
        {
            SwitchCamera(-1);
            audioSource.PlayOneShot(switchSound);
        }
    }

    void SwitchCamera(int direction)
    {
        
        cameras[currentCameraIndex].gameObject.SetActive(false);

        currentCameraIndex += direction;
        if (currentCameraIndex < 0)
        {
            currentCameraIndex = cameras.Length - 1;
        }
        else if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }

        cameras[currentCameraIndex].gameObject.SetActive(true);
        icon.position = cameras[currentCameraIndex].gameObject.transform.position;
    }
}

