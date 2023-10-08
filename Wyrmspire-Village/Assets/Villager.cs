using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public Sprite male_villager;
    public Sprite female_villager;
    private TimeController timeController;
    private Crops crops;
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
    private float maxX = 500;
    private float minX = -500;
    private float maxY = 500;
    private float minY = -500;

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

        crops = FindObjectOfType<Crops>();
        if((int)Random.Range(0, 2) == 0)
            isFemale = false;
        else
            isFemale = true;
    

        hunger = 100;
        happiness = 100;
        pregnant = false;
        eatFlag = false;
        pregnantFlag = false;
        timeSinceDirectionChange = 0.0f;
        changeDirectionInterval = 1.5f;

        // Initilize the target position
        targetPosition = transform.position;
        localDay = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Villager is out of range
        if (transform.position.x > maxX || transform.position.x < minX || transform.position.y > maxY || transform.position.y < minY)
        {
            transform.position = new Vector2(0, 0);
        }
        timeSinceDirectionChange += Time.deltaTime;
        if (timeSinceDirectionChange >= changeDirectionInterval)
        {
            //Vector2 newTargetPosition = GetPositionWithoutObstacle();
            targetPosition = GetPositionWithoutObstacle();
            //targetPosition = new Vector2(newTargetPosition.x, newTargetPosition.y);
            timeSinceDirectionChange = 0.0f;
        }

        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1.0f);

        if (hit.collider != null)
        {
            Vector2 newRandomDirection = Random.insideUnitCircle.normalized;
            targetPosition = new Vector2(transform.position.x + newRandomDirection.x, transform.position.y + newRandomDirection.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);



        // Daily events
        if (localDay != timeController.Day)
        {
            localDay = timeController.Day;
            if (hunger < 100 && !eatFlag)
            {
                hunger+=25;
                eatFlag = true;
                crops.amount--;
            }
            // if (hunger <= 0)
            // {
            //     villager.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            // }

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

        if((int)Random.Range(0, 2) == 0)
        {
            newVillager.isFemale = false;
            newVillager.GetComponent<SpriteRenderer>().sprite = male_villager;   
        }
        else
        {
            newVillager.isFemale = true;
            newVillager.GetComponent<SpriteRenderer>().sprite = female_villager;
        }
        // newVillager.isFemale = Random.Range(0, 2) == 0; // Randomize gender

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

    Vector2 GetPositionWithoutObstacle()
    {
        Vector2 randomPosition = Vector2.zero;
        bool obstacleDetected = true;
        int maxAttempts = 10;
        int attempts = 0;

        while(obstacleDetected && attempts < maxAttempts)
        {
            attempts++;

            float randomX = Random.Range(-750.0f, 750.0f);
            float randomY = Random.Range(-750.0f, 750.0f);

            targetPosition = new Vector2(randomX, randomY);

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(randomPosition, 10.0f);

            bool obstacleFound = false;

            foreach (Collider2D collider in hitColliders)
            {
                if (collider.gameObject.CompareTag("Grid"))
                {
                    obstacleFound = true;
                    break;
                }
            }

            if (!obstacleFound)
            {
                obstacleDetected = false;
            }

            RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.zero, 1.0f);

            if (hit.collider == null)
            {
                obstacleDetected = false;
            }
        }
        return targetPosition;
    }
}
