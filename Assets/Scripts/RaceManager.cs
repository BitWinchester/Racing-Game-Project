using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour {
    //Manager Loads
    //Runs a 1,2,3 countdown 
    //Start tracking the total time 
    //Record track time at end of level
    private float startTime;
    private bool isRaceStarted = false;
    public bool IsRacingStarted { get { return isRaceStarted; } }

    private bool isRaceFinished;
    public bool IsRaceFinished { get { return isRaceFinished; } }


    public int totalCheckpointsToFinish;


    public float countdownTime = 3;
    public Text countdownText;
    public Text raceTotalTimeText;
    public GameObject inGameHud;
    public GameObject endGamePanel;
    public Text finalTimeText;
    private float finalTime;

    private float ellapsedTime;
    



    void Start ()
    {

        StartCoroutine(CountDownTimer());
	}

	
	// Update is called once per frame
	void Update ()
    {

        if (isRaceFinished)
        {
            inGameHud.SetActive(false);
            endGamePanel.SetActive(true);
            finalTimeText.text = finalTime.ToString();
        }

        if(totalCheckpointsToFinish == CheckPointManager.CurrentCheckpoint-1)
        {
            //Stop the timer collect the final time for the track
            isRaceFinished = true;
            finalTime = ellapsedTime;
            raceTotalTimeText.text = finalTime.ToString();
        }
        else
        {
            TotalRaceTime();
        }
        
	}


    private IEnumerator CountDownTimer()
    {

        while (isRaceStarted == false)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime -= 1f;
            if(countdownTime == 0)
            {
                isRaceStarted = true;
                startTime = Time.time;
                countdownText.enabled = false;
                StopCoroutine(CountDownTimer());
            }
           
        }

    }


    void TotalRaceTime()
    {

        //Keep track of the current time
        if (isRaceStarted)
        {
            ellapsedTime = Time.time - startTime;
            raceTotalTimeText.text = ellapsedTime.ToString();






        }
    }

 
}
