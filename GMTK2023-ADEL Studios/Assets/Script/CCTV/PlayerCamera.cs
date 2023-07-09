using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;

    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CameraOne();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CameraTwo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CameraThree();
        }
    }

    void CameraOne()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);

        Canvas1.SetActive(true);
        Canvas2.SetActive(false);
        Canvas3.SetActive(false);
    }
    void CameraTwo()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
        Camera3.SetActive(false);

        Canvas1.SetActive(false);
        Canvas2.SetActive(true);
        Canvas3.SetActive(false);
    }
    void CameraThree()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera3.SetActive(true);

        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
        Canvas3.SetActive(true);
    }
}
