using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSphereRot : MonoBehaviour
{
    public Renderer holomat;
    public GameObject target;
    public GameObject viewCube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (viewCube.GetComponent<eyecheck>().initialized)
        {
            Vector3 currentAngle =  transform.position - target.transform.position;
            currentAngle.Normalize();
            holomat.material.SetVector("_HoloDirection", new Vector4(currentAngle.x, currentAngle.y, currentAngle.z, 0));

        }
      
    }
}
