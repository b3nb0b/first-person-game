using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReceiver : MonoBehaviour
{
    public Color lightColor;
    private Material material;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void ReceiveLight(Color color)
    {
        material.SetColor("_LightColor", color);
    }
}
