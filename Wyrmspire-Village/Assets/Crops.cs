using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    private int localAmount = 50;
    private TimeController timeController;
    private Weather weather;
    private int localDay = 0;

    public int amount
        {
            get { return amount; }
            set { amount = value; }
        }

    // Start is called before the first frame update
    void Start()
    {
        timeController = FindObjectOfType<TimeController>();
        weather = FindObjectOfType<Weather>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get day from day class
        localDay = timeController.day;

        if (localDay != timeController.day)
        {
            // A day has passed
            // Increase food amount
            if (weather.raining == true)
            {
                localAmount += 30;
            }
            else
                localAmount += 20;
        }
        localDay = timeController.day;
    }
}
