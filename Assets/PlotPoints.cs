using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastPSP1 : MonoBehaviour
{
    public TextAsset csvFile;



    void Start()
    {
        Debug.Log("StartCoroutine");
        StartCoroutine(ReadTxt());
    }

   

    IEnumerator ReadTxt()
    {
        // Split by both '\r' and '\n' to handle different line endings
        string[] records = csvFile.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // Start from the second record if you have headers
        for (int i = 2; i < records.Length; i++)
        {
            string[] fields = records[i].Split(',');

            // Check if the fields array has at least 3 elements to prevent index out of range
            if (fields.Length >= 3)
            {
                // Log position values (you can remove these logs in production for better performance)
                Debug.Log("x :" + fields[0]);
                Debug.Log("y :" + fields[1]);
                Debug.Log("z :" + fields[2]);

                // Move the object to the new position (ensure the values are valid floats)
                if (float.TryParse(fields[0], out float x) && float.TryParse(fields[1], out float y) && float.TryParse(fields[2], out float z))
                {
                    transform.position = new Vector3(x, y, z);
                }
                else
                {
                    Debug.LogWarning("Invalid float values in CSV file.");
                }
            }
            else
            {
                Debug.LogWarning("Invalid record at line " + (i + 1));
            }

            // Wait for 1 second before processing the next record
            yield return new WaitForSeconds(0.000000000000000000000000001f);
        }
    }
}
