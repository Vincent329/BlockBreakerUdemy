using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float min = 1.22f;
    [SerializeField] float max = 14.78f;
    float mousePositionX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // update the position of the paddle every frame
    {

        // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits); // returns the position of the mouse relative to the size of the screen, shows as a unit between 0 - 1
        // 16 unity units, since our Canvas Size is 6, and it follows 4:3 ratio
        // never want to put a number unless it's 
        mousePositionX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y); // go to this position here
        paddlePos.x = Mathf.Clamp(mousePositionX, min, max);
        transform.position = paddlePos;
    }
}
