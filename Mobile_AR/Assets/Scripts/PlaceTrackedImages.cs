using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedImages : MonoBehaviour
{
    private ARTrackedImageManager _trackedImageManger;

    public GameObject[] ArPrefabs;

    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();
    void Awake()
    {
        _trackedImageManger = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        _trackedImageManger.trackedImagesChanged += OnTrackedImagesChanged;        
    }

    void OnDisable()
    {
        _trackedImageManger.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    public void OnTrackedImagesChanged (ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            var imageName = trackedImage.referenceImage.name;

            foreach (var curPrefab in ArPrefabs)
            {
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0 && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    _instantiatedPrefabs[imageName] = newPrefab;
                    Debug.Log("Instantiated " + imageName);
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (_instantiatedPrefabs.ContainsKey(trackedImage.referenceImage.name))
            {
                _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
            }
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            if (_instantiatedPrefabs.ContainsKey(trackedImage.referenceImage.name))
            {
                Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
                _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
            }
        }
    }

    
}
