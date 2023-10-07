using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private TextMeshProUGUI dayText;

    private DateTime currentTime;

    public DateTime dayTime;
    private bool flag;
    public int day;

    public int Day
        {
            get { return day; }
            set { day = value; }
        }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        day = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
            if (timeText.text == "00:00")
            {
                if (flag == false)
                {
                    dayTime = dayTime.AddDays(1);
                    day++;
                    dayText.text = dayTime.ToString("dd");
                    flag = true;
                }
            }
            if (timeText.text == "12:00")
            {
                flag = false;
            }
        }
    }
}
