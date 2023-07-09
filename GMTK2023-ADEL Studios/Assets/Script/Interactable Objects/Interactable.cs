using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable: MonoBehaviour
{
    public Sprite icon;
    public Transform UI;
    private Image img;

    public Image Img { get => img; }

    public void createImage()
    {
        GameObject imageObject = new GameObject("Icon " + transform.name);
        img = imageObject.AddComponent<Image>();
        img.sprite = icon;
        imageObject.transform.SetParent(UI.transform, false);
    }

    public abstract void Interact();
}
