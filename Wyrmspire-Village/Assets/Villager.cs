using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private TimeController timeController;
    private static bool isFemale;
    private float hunger;
    private float happiness;
    private float moveSpeed = 30.0f;
    private bool pregnant;
    private bool eatFlag = false;
    private bool pregnantFlag = false;
    private Vector3 targetPosition;
    private int localDay;
    // Start is called before the first frame update

/*
    public Villager(bool sex, Vector3 targetPosition)
    {
        this.sex = sex;
        this.hunger = 100;
        this.happiness = 100;
        this.moveSpeed = 1.0f;
        this.pregnant = false;
        this.eatFlag = false;
        this.pregnantFlag = false;
        this.targetPosition = targetPosition;
    }
*/

    void Start()
    {
        timeController = FindObjectOfType<TimeController>();
        if((int)Random.Range(0, 2) == 0)
            isFemale = false;
        else
            isFemale = true;
    
        hunger = 100;
        happiness = 100;
        pregnant = false;
        eatFlag = false;
        pregnantFlag = false;

        targetPosition = transform.position;
        localDay = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            float randomX = Random.Range(-10f, 10f);
            float randomZ = Random.Range(-10f, 10f);
            targetPosition = new Vector3(randomX, transform.position.y, randomZ);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Daily events
    if (localDay != timeController.Day)
    {
        localDay = timeController.Day;
        if (hunger < 100 && eatFlag == false)
        {
            // TODO inverse proportion between eat chance and hunger
            if (hunger < (int)Random.Range(0, 100))
            {
                hunger+=25;
                eatFlag = true;
            }
        }

        if (pregnant == false && isFemale == true && pregnantFlag == false)
        {
            if((int)Random.Range(0, 4) == 0)
            {
                if (happiness > (int)Random.Range(0, 100))
                {
                    pregnant = true;
                }
            }
            pregnantFlag = true;
        }
        if (pregnant == false)
        {
            pregnantFlag = false;
        }
    }
    eatFlag = false;
    }
}
