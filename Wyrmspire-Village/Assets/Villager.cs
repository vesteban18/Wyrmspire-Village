using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    Random random = new Random();

    private static bool sex;
    private float hunger;
    private float happiness;
    private float moveSpeed = 1.0f;
    private bool pregnant;
    private bool eatFlag = false;
    private bool pregnantFlag = false;
    private Vector3 targetPosition;
    private int localDay;
    // Start is called before the first frame update

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

    void Start()
    {
        if((int)random.Next(0, 2) == 0)
            sex = male;
        else
            sex = female;

        hunger = 100;
        happiness = 100;
        pregnant = false;
        eatFlag = false;
        pregnantFlag = false;

        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            float randomX = Random.Range(-10f, 10f);
            float randomZ = Random.Range(-10f, 10f);
            targetPosition = new vector3(randomX, transform.position.y, randomZ);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // Daily events
    if (localDay != TimeController.day)
    {
        localDay = TimeControl.day;
        if (hunger < 100 && eatFlag == false)
        {
            // TODO inverse proportion between eat chance and hunger
            if (hunger < (int)random.Next(0, 100))
            {
                hunger+=25;
                eatFlag = true;
            }
        }
        if ()

        if (pregnant == false && sex == female && pregnantFlag == false)
        {
            if((int)random.Next(0, 4) == 0)
            {
                if (happiness > (int)random.Next(0, 100))
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
