using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private TimeController timeController;
    private bool isFemale;
    private float hunger;
    private float happiness;
    private float moveSpeed = 30.0f;
    private bool pregnant;
    private bool eatFlag = false;
    private bool pregnantFlag = false;
    private Vector2 targetPosition;
    private int localDay;
    private float timeSinceDirectionChange;
    private float changeDirectionInterval;
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
        isFemale = Random.Range(0, 2) == 0;
        hunger = 100;
        happiness = 100;
        pregnant = false;
        eatFlag = false;
        pregnantFlag = false;
        timeSinceDirectionChange = 0.0f;
        changeDirectionInterval = 0.5f;

        // Initilize the target position
        targetPosition = transform.position;
        localDay = -1;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDirectionChange += Time.deltaTime;
        if (timeSinceDirectionChange >= changeDirectionInterval)
        {
            float randomX = Random.Range(-500.0f, 500.0f);
            float randomY = Random.Range(-500.0f, 500.0f);
            targetPosition = new Vector2(randomX, randomY);
            timeSinceDirectionChange = 0.0f;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Daily events
        if (localDay != timeController.Day)
        {
            localDay = timeController.Day;
            if (hunger < 100 && !eatFlag)
            {
                // TODO inverse proportion between eat chance and hunger
                if (hunger < (int)Random.Range(0, 100))
                {
                    hunger+=25;
                    eatFlag = true;
                }
            }

            if (!pregnant && isFemale && !pregnantFlag)
            {
                if((int)Random.Range(0, 4) == 0)
                {
                    if (happiness > Random.Range(0, 100))
                    {
                        TryReproduce();
                    }
                }
                pregnantFlag = true;
            }
            if (!pregnant)
            {
                pregnantFlag = false;
            }
        }
    eatFlag = false;
    }

    public bool IsReadyForReproduction()
    {
        if (!isFemale || pregnant)
        {
            return false;
        }
        
        return true;
    }

    private void TryReproduce()
    {
        if (IsReadyForReproduction())
        {
            Debug.LogError("Prego.");
            Vector2 spawnPosition = new Vector2(transform.position.x + 2, transform.position.y);
            CreateChildVillager(spawnPosition);

            // Optionally, reset pregnancy status and other conditions
            pregnant = true;
        }
    }

    private void CreateChildVillager(Vector2 spawnPosition)
    {
        GameObject newVillagerObject = Instantiate(gameObject, spawnPosition, Quaternion.identity);
        Villager newVillager = newVillagerObject.GetComponent<Villager>();

        newVillager.isFemale = Random.Range(0, 2) == 0; // Randomize gender

        // Set other properties for the child Villager, such as age, health, etc.
        newVillager.hunger = 75;
        newVillager.happiness = 75;

        // Add the child Villager to your game's management system (e.g., VillagerManager).
        VillagerManager manager = FindObjectOfType<VillagerManager>();

        if(manager != null)
        {
            manager.CreateVillager();
        }
        else{
            Debug.LogError("VillagerManager not found in the scene.");
        }
    }
}
