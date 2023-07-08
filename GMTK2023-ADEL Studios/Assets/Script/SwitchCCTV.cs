using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCCTV : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;
    public Camera camera5;
    public Camera camera6;
    public Camera camera7;
    public Camera camera8;
    public Camera camera9;
    public Camera camera10;
    public Camera camera11;
    public Camera camera12;
    public Camera camera13;
    public Camera camera14;
    public Camera camera15;
    public Camera camera16;
    public Camera camera17;
    public Camera camera18;
    public Camera camera19;
    public Camera camera20;
    public Camera camera21;
    public Camera camera22;
    public Camera camera23;
    public Camera camera24;
    public Camera camera25;
    public Camera camera26;
    public Camera camera27;
    public Camera camera28;
    public Camera camera29;
    public Camera camera30;


    private int currentCameraIndex = 0;

    void Start()
    {
        cameras.Add(camera1);
        cameras.Add(camera2);
        cameras.Add(camera3);
        cameras.Add(camera4);
        cameras.Add(camera5);
        cameras.Add(camera6);
        cameras.Add(camera7);
        cameras.Add(camera8);
        cameras.Add(camera9);
        cameras.Add(camera10);
        cameras.Add(camera11);
        cameras.Add(camera12);
        cameras.Add(camera13);
        cameras.Add(camera14);
        cameras.Add(camera15);
        cameras.Add(camera16);
        cameras.Add(camera17);
        cameras.Add(camera18);
        cameras.Add(camera19);
        cameras.Add(camera20);
        cameras.Add(camera21);
        cameras.Add(camera22);
        cameras.Add(camera23);
        cameras.Add(camera24);
        cameras.Add(camera25);
        cameras.Add(camera26);
        cameras.Add(camera27);
        cameras.Add(camera28);
        cameras.Add(camera29);
        cameras.Add(camera30);


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
