using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class PlaySpawner : MonoBehaviour
{
    public GameObject prefab;

    List<GameObject> spawnedObjects = new List<GameObject>();
    ARRaycastManager raycastManager;
    
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouch(out Vector2 touchPosition))
        {
            return;
        }
        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;

            spawnedObjects.Add(Instantiate(prefab, hitPos.position, hitPos.rotation));
        }
    }

    bool TryGetTouch(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }
}
