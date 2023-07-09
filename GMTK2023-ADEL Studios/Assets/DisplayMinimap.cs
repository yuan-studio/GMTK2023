using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMinimap : MonoBehaviour
{
    [SerializeField] private Camera minimapCamera;

    // Update is called once per frame
    void Update()
    {
        if (minimapCamera != null)
        {
            RenderTexture minimap = minimapCamera.targetTexture;
            if (minimap != null)
            {
                Material mats = GetComponent<Renderer>().material;
                mats.mainTexture = minimap;
            }
        }
    }
}
