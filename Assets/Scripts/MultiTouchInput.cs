using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Touch input MonoBehaviour for handling multiple touch input events.
public class MultiTouchInput : MonoBehaviour
{
    // Reference to touch count Text component in the scene.
    [SerializeField] private TextMeshProUGUI touchCountText;
    [SerializeField] private TextMeshProUGUI objectCountText;
    public GameObject[] spawnedObject;
    Vector3 spawnPos = new Vector3(0, 8, 0);
    int objCount = 0;

    // Update method is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Display the current touch count in the Text component.
        touchCountText.text = "Touch count: " + Input.touchCount;
        objectCountText.text = "Object count: " + objCount;

        // Make sure there are currently touches on the screen (at least one).
        if (Input.touchCount > 0)
        {
           
            // Obtain the Touch in the zero index.
            for (int i = 0; i < Input.touchCount; i++)
            {
               
                Touch touch = Input.GetTouch(i);

                // Log the touch phase events.
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("TouchPhase.Began: " + i);
                    Instantiate(spawnedObject[Input.touchCount - 1], spawnPos, Quaternion.Euler(spawnPos));
                    objCount++;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("TouchPhase.Moved: " + i);
                   
                }
                else if (touch.phase == TouchPhase.Stationary)
                {
                    Debug.Log("TouchPhase.Stationary: " + i);
                    
                }
                else if (touch.phase == TouchPhase.Ended)

                {
                    Debug.Log("TouchPhase.Ended: " + i);
                    
                }
                else if (touch.phase == TouchPhase.Canceled)
                {
                    Debug.Log("TouchPhase.Canceled: " + i);
                   
                }
            }
        }
    }
}