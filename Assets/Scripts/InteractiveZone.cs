using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractiveZone : MonoBehaviour
{
    [SerializeField] InteractiveObject[] prefabsData;

    private List<PossibleObject> possibleObjects;

    private void Awake()
    {
        if (prefabsData.Length == 0)
        {
            enabled = false;
            throw new System.Exception("prefabsData is empty");
        }

        possibleObjects = new List<PossibleObject>();
        foreach (var obj in prefabsData)
        {
            PossibleObject newPossibleObj = new PossibleObject()
            {
                prefab = obj.prefab,
                maximum = obj.maximumOnScene,
                spawned = 0
            };
            possibleObjects.Add(newPossibleObj);
        }
    }

    public void TrySpawnObject(Vector3 position)
    {
        if (possibleObjects.Count == 0) return;

        PossibleObject obj = GetRandomObject();
        obj.spawned++;
        Debug.Log(obj.spawned);
        if (obj.spawned >= obj.maximum)
            possibleObjects.Remove(obj);

        Instantiate(obj.prefab, position, Quaternion.identity, gameObject.transform);
    }

    private PossibleObject GetRandomObject()
    {
        int index = Random.Range(0, possibleObjects.Count);
        PossibleObject obj = possibleObjects[index];

        return obj;
    }
}
