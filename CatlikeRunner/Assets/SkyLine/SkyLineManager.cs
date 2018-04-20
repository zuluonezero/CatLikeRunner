using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLineManager : MonoBehaviour
{

    public Transform prefab;
    public int numberOfObjects;
    public float recycleOffset;
    public Vector3 startPosition;
 

    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;

    // Use this for initialization
    void Start()
    {
        objectQueue = new Queue<Transform>(numberOfObjects);
        nextPosition = startPosition;
        for (int i = 0; i < numberOfObjects; i++)
        {
            Transform o = (Transform)Instantiate(prefab);
            o.localPosition = nextPosition;
            nextPosition.x += o.localScale.x;
            objectQueue.Enqueue(o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectQueue.Peek().localPosition.x + recycleOffset < Runner.distanceTraveled)
        {
            Transform o = objectQueue.Dequeue();
            o.localPosition = nextPosition;
            nextPosition.x += o.localScale.x;
            objectQueue.Enqueue(o);
        }
    }
}
