using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

//This Code was copied from 'AR Foundation Improved Image Tracking - Dev Enabled'

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    public GameObject[] placeablePrefabs;

    public GameObject WarningMenu;
    public GameObject FunctionMenu;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary <string, GameObject>();
    private ARTrackedImageManager _trackedImageManger;

    void Awake()
    {
        _trackedImageManger = FindObjectOfType<ARTrackedImageManager>();

        foreach(GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            newPrefab.transform.Rotate(-90, 0, 0); // This line is edited by myself
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    void OnEnable()
    {
        _trackedImageManger.trackedImagesChanged += ImageChanged;
    }

    void OnDisable()
    {
        _trackedImageManger.trackedImagesChanged -= ImageChanged;
    }

    void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpadateImage(trackedImage);
            WarningMenu.SetActive(false);
            FunctionMenu.SetActive(true);

        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpadateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedPrefabs[trackedImage.name].SetActive(false);
            WarningMenu.SetActive(true);
            FunctionMenu.SetActive(false);

        }
    }

    void UpadateImage(ARTrackedImage trackedImage)
    {
        string name =trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach(GameObject go in spawnedPrefabs.Values)
        {
            if (go.name != name)
            {
                go.SetActive(false);
            }
        }
    }
   
}
