using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeswitch : MonoBehaviour
{
    public GameObject[] cursors = new GameObject[3];
    int currentCursor = 0;

    private void Update()
    {

      
    }

    public void SwitchCursor()
    {
        cursors[currentCursor].SetActive(false);
        currentCursor++;
        if (currentCursor >= cursors.Length) currentCursor = 0;
        cursors[currentCursor].SetActive(true);
    }
}
