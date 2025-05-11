using UnityEngine;

public class Objective : MonoBehaviour
{

    public float minX = -5f; 
    public float maxX = 5f;  
    public float minY = -5f; 
    public float maxY = 5f;  
    public float minDistanceFromPlayer = 2f; 
    private Transform player; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Respawn();
        }
    }

    private void Respawn()
    {
        if (player == null) return;

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
            GameObject newObjective = Instantiate(gameObject, newPosition, Quaternion.identity);
            newObjective.SetActive(true);
            newObjective.GetComponent<Objective>().player = player;
        }

    }
}
