using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{

    public Transform player;          
    public Transform objective;       
    public TextMeshProUGUI distanceText; 
    public float verticalOffset = 150f;
    public float horizontalOffset = 20f;
    private Camera mainCamera;        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {


        GameObject objectiveGO = GameObject.FindWithTag("Objective");

        objective = objectiveGO.transform;

        float distance = Vector2.Distance(player.position, objective.position);

        distanceText.text = $"Distance: {distance:F2}";

        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(player.position);

        Vector3 textScreenPos = new Vector3(playerScreenPos.x + horizontalOffset, playerScreenPos.y + verticalOffset, playerScreenPos.z);

        distanceText.rectTransform.position = textScreenPos;
    }
}
