using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Touch input MonoBehaviour for handling multiple touch input events.
public class MultiTouchInput : MonoBehaviour
{
    // Reference to touch count Text component in the scene.
    [SerializeField] private TextMeshProUGUI touchCountText;
    [SerializeField] private TextMeshProUGUI spawnedObjectCountText;
    [SerializeField] private TextMeshProUGUI pointCountText;
    [SerializeField] private TextMeshProUGUI levelCountText;
    public GameObject[] spawnedObject;
    Vector3 spawnPos = new Vector3(0, 8, 0);
    int objCount;
    public static int score;
    int level;

    // Update method is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Display the current touch count in the Text component.
        touchCountText.text = "Touch count: " + Input.touchCount;
        spawnedObjectCountText.text = "Spawned Object count: " + objCount;
        pointCountText.text = "Points: " + score;
        levelCountText.text = "Level " + level;

        if (score >= 50)
        {
            level++;
            score = 0;
        }

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
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 15f));
                    GameObject ball = Instantiate(spawnedObject[objCount % spawnedObject.Length], touchPosition, Quaternion.identity);
                    objCount++;
                }
                /*else if (touch.phase == TouchPhase.Moved)
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
                   
                }*/
            }
        }
    }

    void CountScore()
    {

    }
}