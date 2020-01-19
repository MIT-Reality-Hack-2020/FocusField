using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class addAnchor : MonoBehaviour
{
    public WorldAnchor anchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void onEnable()
    {
        anchor = this.gameObject.AddComponent<WorldAnchor>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
