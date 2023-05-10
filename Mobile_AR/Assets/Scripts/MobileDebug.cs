using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobileDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPressButon()
    {
        Debug.Log("Button Pressed");
    }
    public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
