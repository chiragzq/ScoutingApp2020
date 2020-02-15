using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Location : MonoBehaviour
{
    public Canvas canvas;
    public Image field;
    public Image grid;
    public Image robotIcon;

    public GameObject leftControls;
    public Button leftFlip;
    public Button leftInnerPlus;
    public Button leftInnerMinus;
    public TextMeshProUGUI leftInnerText;
    public Button leftOuterPlus;
    public Button leftOuterMinus;
    public TextMeshProUGUI leftOuterText;
    public Button leftLowerPlus;
    public Button leftLowerMinus;
    public TextMeshProUGUI leftLowerText;
    public Button leftDropsPlus;
    public Button leftDropsMinus;
    public TextMeshProUGUI leftDropsText;
    public Button leftSubmit;


    public GameObject rightControls;
    public Button rightFlip;
    public Button rightInnerPlus;
    public Button rightInnerMinus;
    public TextMeshProUGUI rightInnerText;
    public Button rightOuterPlus;
    public Button rightOuterMinus;
    public TextMeshProUGUI rightOuterText;
    public Button rightLowerPlus;
    public Button rightLowerMinus;
    public TextMeshProUGUI rightLowerText;
    public Button rightDropsPlus;
    public Button rightDropsMinus;
    public TextMeshProUGUI rightDropsText;
    public Button rightSubmit;


    private Vector2 topLeft;
    private Vector2 bottomRight;

    private const int gridWidth = 15;
    private const int gridHeight = 9;
    private float cellSize;

    private float _ratio;

    // Start is called before the first frame update
    void Start()
    {
        _ratio = Screen.width / 800f;
        float screenWidth = canvas.GetComponent<RectTransform>().rect.width;
        float screenHeight = canvas.GetComponent<RectTransform>().rect.height;
        float ratio = (float)screenWidth / screenHeight;
        float image = 2048f/980;
        if(ratio > image) { // height is constraining
            field.rectTransform.sizeDelta = new Vector2(image * screenHeight, screenHeight);
            grid.rectTransform.sizeDelta = new Vector2(image * screenHeight, screenHeight);
            topLeft = new Vector2((screenWidth - image * screenHeight) / 2, screenHeight);
            bottomRight = new Vector2((screenWidth - image * screenHeight) / 2 + image * screenHeight, 0);

            cellSize = screenHeight / gridHeight;
        } else {
            field.rectTransform.sizeDelta = new Vector2(800, 800 / image);
            grid.rectTransform.sizeDelta = new Vector2(800, 800 / image);
            topLeft = new Vector2(0, (screenHeight - 800 / image) / 2 + 800 / image);
            bottomRight = new Vector2(800, (screenHeight - 800 / image) / 2);

            cellSize = screenWidth / gridWidth * 1642f / 2048f;
        }
        robotIcon.enabled = false;

        float xRot = 0, yRot = 0;
        if(!Variables.currentLocation.red ^ Variables.currentLocation.side) 
            yRot = 180;
        if(Constants.flipLocation) 
            xRot = 180;
        field.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
        if(Variables.currentLocation.side) 
            grid.transform.localRotation = Quaternion.Euler(0, 180, 0);

        if(Variables.currentLocation.side) {
            rightControls.SetActive(false);
            leftFlip.onClick.AddListener(() => {
                Constants.setFlipped(!Constants.flipLocation);
                 if(Constants.flipLocation) 
                    xRot = 180;
                else
                    xRot = 0;
                field.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
            });

            leftInnerPlus.onClick.AddListener(innerPlusHandler);
            leftInnerMinus.onClick.AddListener(innerMinusHandler);
            leftOuterPlus.onClick.AddListener(outerPlusHandler);
            leftOuterMinus.onClick.AddListener(outerMinusHandler);
            leftLowerPlus.onClick.AddListener(lowerPlusHandler);
            leftLowerMinus.onClick.AddListener(lowerMinusHandler);
            leftDropsPlus.onClick.AddListener(dropsPlusHandler);
            leftDropsMinus.onClick.AddListener(dropsMinusHandler);
        } else {    
            leftControls.SetActive(false);
            rightFlip.onClick.AddListener(() => {
                Constants.setFlipped(!Constants.flipLocation);
                 if(Constants.flipLocation) 
                    xRot = 180;
                else
                    xRot = 0;
                field.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
            });

            rightInnerPlus.onClick.AddListener(innerPlusHandler);
            rightInnerMinus.onClick.AddListener(innerMinusHandler);
            rightOuterPlus.onClick.AddListener(outerPlusHandler);
            rightOuterMinus.onClick.AddListener(outerMinusHandler);
            rightLowerPlus.onClick.AddListener(lowerPlusHandler);
            rightLowerMinus.onClick.AddListener(lowerMinusHandler);
            rightDropsPlus.onClick.AddListener(dropsPlusHandler);
            rightDropsMinus.onClick.AddListener(dropsMinusHandler);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Variables.currentLocation.side) {
            leftInnerText.text = Variables.currentLocation.currentCycle.inner + "";
            leftOuterText.text = Variables.currentLocation.currentCycle.outer + "";
            leftLowerText.text = Variables.currentLocation.currentCycle.lower + "";
            leftDropsText.text = Variables.currentLocation.currentCycle.drops + "";
        } else {
            rightInnerText.text = Variables.currentLocation.currentCycle.inner + "";
            rightOuterText.text = Variables.currentLocation.currentCycle.outer + "";
            rightLowerText.text = Variables.currentLocation.currentCycle.lower + "";
            rightDropsText.text = Variables.currentLocation.currentCycle.drops + "";
        }

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
        if(x >= 0 && y >= 0) {
            x -= topLeft.x;
            y -= bottomRight.y;

            int cellX = (int)(x / cellSize);
            int cellY = (int)(y / cellSize);
            if(cellX >= 15 || cellY >= 9) return;

            robotIcon.rectTransform.sizeDelta = new Vector2(cellSize * 0.85f, cellSize * 0.85f);

            Vector3 cellCenter = new Vector3((cellX + 0.5f) * cellSize + topLeft.x, (cellY + 0.5f) * cellSize + bottomRight.y / 1.1f, 10f) * canvas.scaleFactor;
            Debug.Log(cellX + ", " + cellY);
            robotIcon.transform.position =  Camera.main.ScreenToWorldPoint(cellCenter);
            // robotIcon.enabled = true;
        }   
    }

    void outerPlusHandler() {
        Variables.currentLocation.currentCycle.outer++;
    }

    void outerMinusHandler() {
        if(Variables.currentLocation.currentCycle.outer > 0) {
            Variables.currentLocation.currentCycle.outer--;
        }
    }

    void innerPlusHandler() {
        Variables.currentLocation.currentCycle.inner++;
    }

    void innerMinusHandler() {
        if(Variables.currentLocation.currentCycle.inner > 0) {
            Variables.currentLocation.currentCycle.inner--;
        }
    }
    void lowerPlusHandler() {
        Variables.currentLocation.currentCycle.lower++;
    }

    void lowerMinusHandler() {
        if(Variables.currentLocation.currentCycle.lower > 0) {
            Variables.currentLocation.currentCycle.lower--;
        }
    }

    void dropsPlusHandler() {
        Variables.currentLocation.currentCycle.drops++;
    }

    void dropsMinusHandler() {
        if(Variables.currentLocation.currentCycle.drops > 0) {
            Variables.currentLocation.currentCycle.drops--;
        }
    }
}
