using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereToggle : MonoBehaviour
{
    public Renderer holomat;
    public bool holo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void turnRendOn()
    {

        holomat.material.SetColor("_Color", new Color(0.5f, 0.8f, 1, 1));
    }

    public void turnRendOff()
    {

        holomat.material.SetColor("_Color", new Color(0, 0, 0, 0));
    }
}
