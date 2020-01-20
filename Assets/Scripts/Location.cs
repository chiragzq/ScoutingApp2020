using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Location : MonoBehaviour
{
    public Canvas canvas;
    public Image field;

    private Vector2 topLeft;
    private Vector2 bottomRight;

    private float _ratio;

    // Start is called before the first frame update
    void Start()
    {
        _ratio = Screen.width / 800f;
        float screenWidth = canvas.GetComponent<RectTransform>().rect.width;
        float screenHeight = canvas.GetComponent<RectTransform>().rect.height;
        float ratio = (float)screenWidth / screenHeight;
        float image = (float)2048f/980;
        if(ratio > image) { // height is constraining
            field.rectTransform.sizeDelta = new Vector2(image * screenHeight, screenHeight);
            topLeft = new Vector2((screenWidth - image * screenHeight) / 2, screenHeight);
            bottomRight = new Vector2((screenWidth + image * screenHeight) / 2, screenHeight);
        } else {
            field.rectTransform.sizeDelta = new Vector2(800, 800 / image);
        }
        Debug.Log(topLeft);
        Debug.Log(bottomRight);
    }

    // Update is called once per frame
    void Update()
    {
        float x = -1;
        float y = -1;
        if(Input.GetMouseButtonDown(0)) {
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
        } else {
            for (var i = 0; i < Input.touchCount; ++i) {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began) {
                    x = touch.position.x;
                    y = touch.position.y;
                }
            }
        }
        x *= 1 / _ratio;
        y *= 1 / _ratio;
        if(x != -1 && y != -1) {
            Debug.Log(x + ", " + y);
        }   
    }
}
