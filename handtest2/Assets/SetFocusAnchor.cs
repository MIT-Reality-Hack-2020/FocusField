using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class SetFocusAnchor : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform focusGazeTransform;

    public float isSettingCounter;
  

    // Start is called before the first frame update
    void Start()
    {
        isSettingCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void SetFocus()
    {
        if(isSettingCounter == 3)
        {
            focusGazeTransform = this.transform;
            Instantiate(targetPrefab, focusGazeTransform.position, Quaternion.identity);
        }
        //get transform location of follow gaze cube
        //instantiate prefab at transform location.
        //game object should set world anchor on start.
    }

    public void IncrementCounter()
    {
        isSettingCounter += Time.deltaTime;
    }
}
