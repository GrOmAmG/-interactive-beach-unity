using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider == null) return;

            GameObject go = hit.collider.gameObject;
            InteractiveZone zone = go.GetComponent<InteractiveZone>();

            if (zone == null) return;

            zone.TrySpawnObject(hit.point);
        }
    }
}
