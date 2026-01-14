using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimeStart=false;
    public Script1 player;
    private TextMeshProUGUI CountDownTime;
    void Awake()
    {
        CountDownTime = GetComponent<TextMeshProUGUI>();

        if (CountDownTime == null)
        {
            Debug.LogError("Timer is NOT on a TextMeshProUGUI object!");
            enabled = false;
            return;
        }
    }
    void Start()
    {
        TimeLeft=GameSettings.GetCombatTime();
        TimeStart=true;
    }
    void UpdateTimerUI()
    {
        int min=Mathf.FloorToInt(TimeLeft/60);
        int sec=Mathf.FloorToInt(TimeLeft%60);
        CountDownTime.text = string.Format("{0:00}:{1:00}", min, sec);
    }
    void CountDown()
    {
        if (TimeStart == false)
        {
            return;
        }
        else if (TimeStart == true)
        {
            TimeLeft-=Time.deltaTime;
            UpdateTimerUI();
            if (TimeLeft <= 0)
            {
                TimeLeft=0;
                TimeStart=false;
                Debug.Log("Times Up");
                player.Loser();
            }
        }
    }
    void Update()
    {
        if (TimeStart==true){
            CountDown();
        }
    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
