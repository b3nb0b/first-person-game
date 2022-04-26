using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public float distance;
    public LightReceiver[] lightReceivers;
    public PointLightEmitter[] pointLightEmitters;

    void Start()
    {
        pointLightEmitters = FindObjectsOfType<PointLightEmitter>();
        lightReceivers = FindObjectsOfType<LightReceiver>();

        foreach (var emitters in pointLightEmitters)
        {
            emitters.lightManager = this;
        }
    }

    void Update()
    {
        Debug.Log(lightReceivers.Length);

        for (int x = 0; x < pointLightEmitters.Length; x++)
        {
            for (int i = 0; i < lightReceivers.Length; i++)
            {
                distance = Vector3.Distance(pointLightEmitters[x].transform.position, lightReceivers[i].transform.position);

                pointLightEmitters[x].LightCalculate(distance, lightReceivers[i]);
            }
        }
    }
}
