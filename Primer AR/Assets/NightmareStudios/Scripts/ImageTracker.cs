using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager imageManager;

    public Text text;
    
    void Awake()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChange;
    }

    public void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChange;
    }

    public void OnImageChange(ARTrackedImagesChangedEventArgs arg) 
    {
        foreach (var trackedImage in arg.added)
        {
            Debug.Log(trackedImage.name);
            text.text = trackedImage.name;
        }
    }
    
}
