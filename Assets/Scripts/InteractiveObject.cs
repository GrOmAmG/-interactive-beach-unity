using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractiveObject", menuName = "ScriptableObjects/InteractiveObject", order = 1)]
public class InteractiveObject : ScriptableObject
{
    public GameObject prefab;
    public int maximumOnScene = 1;
}
