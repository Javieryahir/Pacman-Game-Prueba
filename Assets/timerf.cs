using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerf : MonoBehaviour
{
     public Text timerText;
    public float gameTime;
    public bool mod04;
    public GameObject perderpantalla;

    private bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        
        perderpantalla.SetActive(false);
        stopTimer = true;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimer)
        {
            if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
                DisplayTime(gameTime);
            }
            else
            {
                Debug.Log("Time has run out!");
                gameTime = 0;
                stopTimer = false;
                if(mod04 == true){
                    perderpantalla.SetActive(true);
                    if(Time.timeScale == 1){
                        Time.timeScale = 0;


                    }

                }
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
