using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;


public class eyecheck2 : MonoBehaviour
{
    //
    public GameObject UIthing;
    [SerializeField]
    public float currentSize;
    [SerializeField]
    public float sizeRate;

    [SerializeField]
    public float difInEyeGaze;
    [SerializeField]
    public float startSizeUI;
    [SerializeField]
    public float endSizeUI;
    public float startAlpha;
    public float endAlpha;

    public float angleDif;
    public Vector3 oldAngle = Vector3.zero;

    public GameObject cam;
    public GameObject lookSquare;

    public float percent;
    public Material mat;
    public Renderer rend;



    void Start()
    {
        mat = rend.material;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 currentAngle = lookSquare.transform.position - cam.transform.position;



        float angle = Vector3.Angle(oldAngle, currentAngle);

        if (angle < angleDif)
        {
            if (percent < 100)
            {
                percent += sizeRate * Time.deltaTime;

            }
            else
            {
                percent = Mathf.Clamp(percent, 0, 100);
            }


        }
        else
        {
            percent = 0;
        }

        //Debug.Log(angle);

        UIthing.transform.localScale = Vector3.one * (startSizeUI + (percent / 100) * (endSizeUI - startSizeUI));


        // mat.color = Color.Lerp(mat.color, new Color(1,1,1,percent/100), 0.8f);


        mat.SetColor("_RimColor", new Color(0.8f * percent / 100, 0.8f * percent / 100, 0.8f * percent / 100, 1));


        //mat.rimColor = Color.Lerp(mat.color, new Color(0.5f, 0.5f, 0.5f, percent / 100), 0.8f);
        oldAngle = currentAngle;

        UIthing.transform.rotation = Quaternion.LookRotation(currentAngle, cam.transform.up);
        // UIthing.transform.eulerAngles =currentAngle;
        Debug.Log(currentAngle);
    }



}


