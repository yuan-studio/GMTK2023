using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    bool isRotating = false;
    bool isMoving = false;
    float inputX, inputY;
    float currentRotationX = 0f, currentRotationY = 0f;
    float maxRotationX = 25f;
    float maxRotationY = 25f;
    float minRotationY = -25f;

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if (inputX != 0)
        {
            if (!isMoving)
            {
                isRotating = true;
                Rotate();
            }
        }
        else if (inputY != 0)
        {
            if (!isRotating)
            {
                isMoving = true;
                Updown();
            }
        }
        else
        {
            isRotating = false;
            isMoving = false;
        }
    }

    private void Rotate()
    {
        float rotationAmountX = inputX * 20 * Time.deltaTime;
        float newRotationX = currentRotationX + rotationAmountX;

        newRotationX = Mathf.Clamp(newRotationX, -maxRotationX, maxRotationX);

        float deltaRotationX = newRotationX - currentRotationX;

        transform.Rotate(new Vector3(0f, deltaRotationX, 0f));

        currentRotationX = newRotationX;
    }

    private void Updown()
    {
        float rotationAmountY = inputY * -20 * Time.deltaTime;
        float newRotationY = currentRotationY + rotationAmountY;

        newRotationY = Mathf.Clamp(newRotationY, minRotationY, maxRotationY);

        float deltaRotationY = newRotationY - currentRotationY;

        transform.Rotate(new Vector3(deltaRotationY, 0f, 0f));

        currentRotationY = newRotationY;
    }
}
