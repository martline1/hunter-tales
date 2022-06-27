#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    [SerializeField]
    private Sprite? aliveSprite;

    [SerializeField]
    private Sprite? deathSprite;

    private Image? _image;

    public bool IsAlive { get; private set; }

    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
        SetIsAlive(false);
    }

    public void SetIsAlive(bool value)
    {
        if (_image != null && aliveSprite != null && deathSprite != null)
        {
            IsAlive = value;

            _image.sprite = IsAlive
                ? aliveSprite
                : deathSprite;
        }
    }
}
