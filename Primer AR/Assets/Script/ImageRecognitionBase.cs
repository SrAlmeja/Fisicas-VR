using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognitionBase : MonoBehaviour
{
    ARTrackedImageManager imageManager;

    public Text text;
    private void Awake()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChange;
    }
    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChange;
    }
    public void OnImageChange(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
            text.text = trackedImage.name;
        }
    }

}
