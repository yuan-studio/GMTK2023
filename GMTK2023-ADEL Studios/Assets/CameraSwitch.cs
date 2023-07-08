using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    private int currentCameraIndex = 1;

    void Start()
    {
        cameras.Add(camera1);
        cameras.Add(camera2);
        cameras.Add(camera3);

        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (currentCameraIndex >= 0 && currentCameraIndex < cameras.Count)
        {
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SwitchCamera(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchCamera(1);
        }
    }

    void SwitchCamera(int direction)
    {
        cameras[currentCameraIndex].gameObject.SetActive(false);

        currentCameraIndex += direction;
        if (currentCameraIndex < 0)
        {
            currentCameraIndex = cameras.Count - 1;
        }
        else if (currentCameraIndex >= cameras.Count)
        {
            currentCameraIndex = 0;
        }

        cameras[currentCameraIndex].gameObject.SetActive(true);
    }
}
