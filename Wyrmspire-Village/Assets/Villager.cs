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
        changeDirectionInterval = 0.5f;

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
