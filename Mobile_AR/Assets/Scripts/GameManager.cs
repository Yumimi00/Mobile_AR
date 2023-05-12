using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager : MonoBehaviour
{
    private ImageTracking _imageTracking;
    public GameObject warningMenu;
    public GameObject functionMenu;

    void Start()
    {
        _imageTracking = FindObjectOfType<ImageTracking>();  
    }


}
