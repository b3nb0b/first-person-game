using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightEmitter : AbstractLightEmitter
{
    public override void LightCalculate(float distance, LightReceiver lightReceiver)
    {
        if (distance <= Range)
        {
            emissionColor /= (distance * distance);

            lightReceiver.ReceiveLight(emissionColor);

            Debug.Log(distance);
        }
    }
}
