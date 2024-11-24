using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPath : MonoBehaviour
{
    public LineRenderer lineRenderer;  // Reference to the LineRenderer
    public float pathUpdateRate = 0.1f;  // How often the path updates (in seconds)
    public int maxPoints = 500;  // Max number of points to track in the path
    private float timeSinceLastUpdate = 0f;
    private int currentPointIndex = 0;

    void Start()
    {
        // Initialize the line renderer position count
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Make sure LineRenderer is initialized with at least one point
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        // Update the path at regular intervals
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= pathUpdateRate)
        {
            timeSinceLastUpdate = 0f;
            AddPointToPath();
        }
    }

    void AddPointToPath()
    {
        // Stop adding points once we reach the max
        if (currentPointIndex >= maxPoints) return;

        // Add the current rocket position to the path
        lineRenderer.positionCount = currentPointIndex + 1;
        lineRenderer.SetPosition(currentPointIndex, transform.position);

        // Color code the path based on altitude or other conditions
        Color pathColor = GetColorBasedOnConditions();
        lineRenderer.startColor = pathColor;
        lineRenderer.endColor = pathColor;

        // Increase point index
        currentPointIndex++;
    }

    Color GetColorBasedOnConditions()
    {
        // For example, you could color the path based on altitude or speed
        float altitude = transform.position.magnitude;  // Distance from Earth (assuming Earth is at the origin)

        // Color based on altitude: closer to Earth is red, farther is blue
        if (altitude < 600)  // Low altitude (close to Earth)
            return Color.red;
        else if (altitude < 1000)  // Medium altitude
            return Color.yellow;
        else  // High altitude (farther from Earth)
            return Color.blue;
    }
}
