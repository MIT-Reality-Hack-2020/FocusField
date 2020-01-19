using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerUI : MonoBehaviour
{


    public GameObject UIClock;
    public Image fillImage;

    public GameObject cam;
    public GameObject lookSquare;

    public sphereToggle shader;
    float percent;
    public float sizeRate;

    public eyecheck eyeinit;

    public AudioSource circleCompleteSound;
    
    public AudioSource targetResetSound;

    public bool levelStarted;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (levelStarted)
        {
            
            if (Physics.Raycast(cam.transform.position, lookSquare.transform.position - cam.transform.position, out hit, Mathf.Infinity)&& levelStarted)
            {
                // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
               
                if (percent < 100)
                {
                    percent += sizeRate * Time.deltaTime;

                }
                else
                {

                    Debug.Log("Did Hit");

                    percent = Mathf.Clamp(percent, 0, 100);
                    CompleteLevel();

                }
                fillImage.enabled = true;
                shader.turnRendOff();
            }
            else
            {
                percent = 0;
                fillImage.enabled = false;
                shader.turnRendOn();
            }

        }
        else
        {
            shader.turnRendOff();
        }


        fillImage.fillAmount = percent / 100;

       

        UIClock.transform.rotation = Quaternion.LookRotation(lookSquare.transform.position - cam.transform.position, cam.transform.up);
    }


    public void CompleteLevel()
    {
        levelStarted = false;

        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.75f, "to", 0f, "delay", 0.5f, "time", 1.5, "onupdate", "updateColor2", "easeType", iTween.EaseType.easeOutCubic));
       // fillImage.fillAmount =0;
        circleCompleteSound.Play();

        //playsound
        //percent = 0;
        EndLevel();

    }

    public void updateColor2(float val)
    {
        fillImage.color = new Color(1, 1, 1, val);
        //FadeImage.color = ((1f - val) * StartColor) + (val * EndColor);
    }

    public void StartLevel(float _percentPerSec)
    {

        fillImage.enabled = true;
        sizeRate = _percentPerSec;
        percent = 0;
        levelStarted = true;

    }

    public void EndLevel()
    {
        shader.turnRendOff();
        fillImage.enabled =false;
       
        percent = 0;
        levelStarted = false;

    }
}
