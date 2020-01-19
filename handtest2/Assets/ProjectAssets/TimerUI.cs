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

    public LayerMask raycastMask;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (levelStarted)
        {

            if (Physics.Raycast(cam.transform.position, lookSquare.transform.position - cam.transform.position, out hit, Mathf.Infinity, raycastMask) && levelStarted)
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

    public int currentLevel;

    public GameObject[] UIAward;
    public float[] timerates;
    public void CompleteLevel()
    {
        levelStarted = false;

        // iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.75f, "to", 0f, "delay", 0.5f, "time", 1.5, "onupdate", "updateColor2", "easeType", iTween.EaseType.easeOutCubic));
        // fillImage.fillAmount =0;
        circleCompleteSound.Play();


        UIAward[currentLevel].SetActive(true) ;

        StartCoroutine(plswait());
        //wait 5 sec and false;


        //   0.03262853


        //   iTween.ScaleTo(UIAward, iTween.Hash("scale", new Vector3(transform.localPosition.x, downScale, transform.localPosition.z), "speed", speed, "easetype", "linear"));

        //playsound
        //percent = 0;
        EndLevel();

    }


    IEnumerator plswait()
    {

        yield return new WaitForSeconds(3);
        UIAward[currentLevel].SetActive(false);

    }

    public void updateColor2(float val)
    {
        fillImage.color = new Color(1, 1, 1, val);
        //FadeImage.color = ((1f - val) * StartColor) + (val * EndColor);
    }

    public void StartLevel(float _percentPerSec)
    {
        currentLevel++;
        if (currentLevel >= UIAward.Length) currentLevel = 0;
        fillImage.enabled = true;
        sizeRate = timerates[currentLevel];
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
