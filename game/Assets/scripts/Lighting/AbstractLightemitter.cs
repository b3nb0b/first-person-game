using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLightEmitter : MonoBehaviour
{
    public LightManager lightManager;
    public int Range;
    public int Intensity;
    public Color emissionColor;

    public abstract void LightCalculate(float distance, LightReceiver lightReceiver);
}
