using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    public int amount = 0;
    private TimeController timeController;
    private Weather weather;
    private int localDay = 0;

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
                amount += 30;
            }
            else
                amount +=20;
        }
        localDay = timeController.day;

        //if ()// Villager attempts to take food

        if (amount > 0)
        {
            amount-=1;
        }
        // Else villager gets no food
    }
}
