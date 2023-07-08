using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVSwitch : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;
   
 
    private int currentCameraIndex = 0;

    void Start()
    {
        cameras.Add(camera1);
        cameras.Add(camera2);
        cameras.Add(camera3);
        cameras.Add(camera4);
       

        for (int i = 1; i < cameras.Count; i++)
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
        }
        else if (scroll < 0)
        {
            SwitchCamera(-1);
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



