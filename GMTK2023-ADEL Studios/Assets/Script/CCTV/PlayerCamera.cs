using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private PLAYER_STATE initialState;
    [SerializeField] private float rotateDuration;
    [SerializeField] private AudioSource SFXsource;

    public enum PLAYER_STATE
    { 
        
        MINIMAP = 0,
        CCTV = 1,
        CONTROLS = 2
    }

    private PLAYER_STATE currentState;
    private bool rotating = false;

    private IEnumerator rotateCamera(float degrees)
    {
        rotating = true;

        SFXsource.Play();

        float elapsedTime = 0f;
        float startAngle = transform.rotation.eulerAngles.y;
        float targetAngle = startAngle + degrees;

        while (elapsedTime < rotateDuration)
        {
            float t = elapsedTime / rotateDuration;
            float angle = Mathf.Lerp(startAngle, targetAngle, t);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

        rotating = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
        SFXsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotating)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                int index = (int)currentState;
                index = Mathf.Clamp((index - 1), 0, 2);

                if ((PLAYER_STATE)index != currentState)
                {
                    StartCoroutine(rotateCamera(-90f));
                }

                currentState = (PLAYER_STATE)index;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                int index = (int)currentState;
                index = Mathf.Clamp((index + 1), 0, 2); ;

                if ((PLAYER_STATE)index != currentState)
                {
                    StartCoroutine(rotateCamera(90f));
                }

                currentState = (PLAYER_STATE)index;
            }
        }
    }
}
