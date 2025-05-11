using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{

    public Transform player;          
    public Transform objective;       
    public TextMeshProUGUI distanceText; 
    public float verticalOffset = 50f; 
    private Camera mainCamera;        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || objective == null || distanceText == null)
            return;

        // Calculate the distance between player and objective
        float distance = Vector2.Distance(player.position, objective.position);

        // Update the text to display the distance (rounded to 2 decimal places)
        distanceText.text = $"Distance: {distance:F2}";

        // Position the text above the player
        // Convert player's world position to screen position
        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(player.position);

        // Adjust the position by adding the vertical offset (in screen space)
        Vector3 textScreenPos = new Vector3(playerScreenPos.x, playerScreenPos.y + verticalOffset, playerScreenPos.z);

        // Set the text's position (UI elements use screen space)
        distanceText.rectTransform.position = textScreenPos;
    }
}
