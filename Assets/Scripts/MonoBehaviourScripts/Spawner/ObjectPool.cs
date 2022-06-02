using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private int capacity;

    private List<GameObject> pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawned = Instantiate(prefabs[randomIndex], container.transform);

            spawned.SetActive(false);

            pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = pool.FirstOrDefault(objectFromList => objectFromList.activeSelf == false);

        return result != null;
    }
}
