using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BloodSplatter : MonoBehaviour
{
    public ParticleSystem part;
    public GameObject test;
    public int i;
    public List<ParticleCollisionEvent> collisionEvents;

    public void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Debug.Log(numCollisionEvents);

        GameObject testClone = Instantiate(test, collisionEvents[0].intersection, Quaternion.identity);

        while (i <= numCollisionEvents)
        {
            Debug.Log("i is currently" + " " + i);
            // GameObject testClone = Instantiate(test, collisionEvents[i].intersection, Quaternion.identity);
            Debug.Log("splat");
            i++;
        }
        i = 0;
    }
}