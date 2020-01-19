using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine.UI;
using UnityEngine.XR.WSA;

public class eyecheck : MonoBehaviour
{
    //



    public float sizeRate;


  


    public float angleDif;
    public Vector3 oldAngle = Vector3.zero;

    public GameObject cam;
    public GameObject lookSquare;

    public float percent;
    public bool initialized;


    public GameObject targetPrefab;
  
    public WorldAnchor anchor;
    public GameObject setUPCircle;

    public AnimationCurve setUPcurve;

    public Image setupimg;

    public AudioSource targetPlacedSound;

    public TimerUI startLevel;
    public SpriteRenderer setupFocus;

    void Start()
    {

       // targetPrefab.GetComponent<MeshRenderer>().enabled = false;
        targetPrefab.GetComponent<Collider>().enabled = false;
        initialized = false;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 currentAngle = lookSquare.transform.position - cam.transform.position;



        float angle = Vector3.Angle(oldAngle, currentAngle);

        if (angle  < angleDif)
        {
            if (percent < 100)
            {
                percent += sizeRate * Time.deltaTime;
               if(!initialized) setUPCircle.GetComponent<RectTransform>().localScale = Vector3.one * setUPcurve.Evaluate(percent/100);
                
            }
            else
            {
            
                if (!initialized)
                {
                    //targetPrefab.GetComponent<MeshRenderer>().enabled = true;
                    targetPrefab.GetComponent<Collider>().enabled = true;
                    targetPrefab.transform.position = this.transform.position;
                    // Debug.Log(this.transform.position);
                    //  anchor = targetPrefab.AddComponent<WorldAnchor>();
                    targetPlacedSound.Play();
                    initialized = true;
                    percent = 0;

                    startLevel.StartLevel(20f);
                    setUPCircle.GetComponent<Image>().fillAmount = 0;
                    setupFocus.color = new Color(0, 0, 0, 0);
                    //  iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.75f, "to", 0f, "delay", 0.5f, "time", 1.5, "onupdate", "updateColor", "easeType",iTween.EaseType.easeOutCubic));


                    // iTween.ScaleTo(setUPCircle, iTween.Hash("x", 0.2f, "y", 0.2f, "z", 0.2f, "time", 1.5, "delay", 0, "onupdate", "myUpdateFunction"));

                }
            }
         

        }
        else
        {
            percent = 0;
        }

       
        oldAngle = currentAngle;

        setUPCircle.transform.rotation = Quaternion.LookRotation(lookSquare.transform.position - cam.transform.position, cam.transform.up);

    }

    public void ResetTarget()
    {
        targetPlacedSound.Play();
       // targetPrefab.GetComponent<MeshRenderer>().enabled =false;
        targetPrefab.GetComponent<Collider>().enabled =false;
        percent = 0;
        initialized = false;
        setUPCircle.GetComponent<Image>().fillAmount = 1;
        setupFocus.color = new Color(1, 1, 1, 1);

        startLevel.EndLevel();

    }

    public void updateColor(float val)
    {
        setUPCircle.GetComponent<Image>().color = new Color(1, 1, 1, val);
       //FadeImage.color = ((1f - val) * StartColor) + (val * EndColor);
    }

    public void turnOff()
    {
        setupimg.enabled = false;
    }



}


