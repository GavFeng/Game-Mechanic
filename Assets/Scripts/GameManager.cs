using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform player;          
    public GameObject objective; 

    private GameObject currentObjective; 
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;
    public float minDistanceFromPlayer = 2f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        if (currentObjective != null)
        {
            Destroy(currentObjective);
        }

        SpawnObjective();
    }


    private void SpawnObjective()
    {
        Vector2 newPosition = Vector2.zero;
        bool validPosition = false;


        while (!validPosition)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            newPosition = new Vector2(randomX, randomY);

            float distanceToPlayer = Vector2.Distance(newPosition, player.position);
            if (distanceToPlayer >= minDistanceFromPlayer)
            {
                validPosition = true;
            }
        }

        if (validPosition)
        {
            currentObjective = Instantiate(objective, newPosition, Quaternion.identity);
            currentObjective.SetActive(true);

            Objective objectiveScript = currentObjective.GetComponent<Objective>();
            if (objectiveScript != null)
            {
                objectiveScript.gameManager = this;
            }
        }

    }

}
