using UnityEngine;

public class ObjectivePointer : MonoBehaviour
{
    public Transform player;
    public Transform objective;
    public float radius = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (player == null || objective == null)
            return;

        Vector2 directionToObjective = (objective.position - player.position).normalized;

        Vector2 trianglePosition = (Vector2)player.position + directionToObjective * radius;

        transform.position = trianglePosition;

        float angleToTriangle = Mathf.Atan2(directionToObjective.y, directionToObjective.x) * Mathf.Rad2Deg;


        float rotationAngle = angleToTriangle + 90f + 180f;

        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }


}
