using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager : MonoBehaviour
{
    public TMP_Text myText;
    public ARTrackedImageManager trackedImageManager;
 

    void Start()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        
    }


}
