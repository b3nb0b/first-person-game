using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeTimeRemaining, shakePower;
    private Vector3 startPosition;
    public GameObject head;

    public IEnumerator StartShake(float length, float power)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < length)
        {
            float x = Random.Range(-1f, 1f) * power;
            float y = Random.Range(-1f, 1f) * power;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
