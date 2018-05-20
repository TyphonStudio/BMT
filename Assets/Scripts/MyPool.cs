using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int initialPoolSize;
    [SerializeField]
    private int extensionSize;
    [SerializeField]
    private bool populateOnAwake;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    protected virtual void Awake()
    {
        if (populateOnAwake)
            PopulatePool(initialPoolSize);
    }

    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
            PopulatePool(extensionSize); // create a pool expand method

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);

        return instance;
    }

    public void AddToPool(GameObject objToAdd)
    {
        objToAdd.SetActive(false);
        availableObjects.Enqueue(objToAdd);
    }

    void PopulatePool(int objects)
    {
        for (int i = 0; i < objects; i++)
        {
            var instance = Instantiate(prefab);
            instance.transform.SetParent(transform);
            AddToPool(instance);
        }
    }
}
