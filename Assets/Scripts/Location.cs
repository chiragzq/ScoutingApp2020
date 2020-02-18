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
    public Image robot;

    public GameObject leftControls;
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
    public Button leftBricked;
    public Button leftDefense;
    public Button leftAuton;
        public TextMeshProUGUI leftAutonText;
    public Button leftUndo;
    public Button leftSubmit;
    public Button leftNext;


    public GameObject rightControls;
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
    public Button rightBricked;
    public Button rightDefense;
    public Button rightAuton;
        public TextMeshProUGUI rightAutonText;
    public Button rightUndo;
    public Button rightSubmit;
    public Button rightNext;

    public bool isAuton;
    public int startTimestamp;
    public int defenseTimestamp;
    public int brickedTimestamp;

    private Vector2 topLeft;
    private Vector2 bottomRight;

    private const int gridWidth = 15;
    private const int gridHeight = 9;
    private float cellSize;
    private bool flipY;

    private float _ratio;

    // Start is called before the first frame update
    void Start()
    {
        isAuton = true;
        startTimestamp = currentTime() - 2;

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
        robot.enabled = false;

        float xRot = 0, yRot = 0;

        if(Variables.currentLocation.side)
            flipY = !flipY;
        if(Constants.flipLocation)
            flipY = !flipY;
        if(!Variables.currentLocation.red ^ Variables.currentLocation.side)
            flipY = !flipY;
        
        if(!Variables.currentLocation.red ^ Variables.currentLocation.side) 
            yRot = 180;
        if(Constants.flipLocation) 
            xRot = 180;

        field.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
        if(Variables.currentLocation.side) 
            grid.transform.localRotation = Quaternion.Euler(0, 180, 0);

        // Variables.currentLocation.side = false;
        if(Variables.currentLocation.side) {
            rightControls.SetActive(false);

            leftInnerPlus.onClick.AddListener(innerPlusHandler);
            leftInnerMinus.onClick.AddListener(innerMinusHandler);
            leftOuterPlus.onClick.AddListener(outerPlusHandler);
            leftOuterMinus.onClick.AddListener(outerMinusHandler);
            leftLowerPlus.onClick.AddListener(lowerPlusHandler);
            leftLowerMinus.onClick.AddListener(lowerMinusHandler);
            leftDropsPlus.onClick.AddListener(dropsPlusHandler);
            leftDropsMinus.onClick.AddListener(dropsMinusHandler);
            leftSubmit.onClick.AddListener(submit);
            leftUndo.onClick.AddListener(undo);
            leftNext.onClick.AddListener(next);

            leftAuton.onClick.AddListener(() => {
                isAuton = !isAuton;
                if(isAuton) {
                    leftAutonText.text = "Auton";
                    leftAuton.GetComponent<Image>().color = new Color(103f/255, 15f/255, 219f/255);
                } else {
                    leftAutonText.text = "Teleop";
                    leftAuton.GetComponent<Image>().color = new Color(231f/255, 151f/255, 1f/255);
                }
            });

            leftDefense.onClick.AddListener(() => {
                 if(defenseTimestamp == 0) {
                    defenseTimestamp = currentTime();
                    leftDefense.GetComponent<Image>().color = new Color(60f/255, 9f/255, 128f/255);
                } else {
                    Variables.currentLocation.defenseTime += currentTime() - defenseTimestamp;
                    defenseTimestamp = 0;
                    leftDefense.GetComponent<Image>().color = new Color(103f/255, 15f/255, 219f/255);
                }
            });

            leftBricked.onClick.AddListener(() => {
                 if(brickedTimestamp == 0) {
                    brickedTimestamp = currentTime();
                    leftBricked.GetComponent<Image>().color = new Color(60f/255, 9f/255, 128f/255);
                } else {
                    Variables.currentLocation.brickTime += currentTime() - brickedTimestamp;
                    brickedTimestamp = 0;
                    leftBricked.GetComponent<Image>().color = new Color(103f/255, 15f/255, 219f/255);
                }
            });
        } else {    
            leftControls.SetActive(false);

            rightInnerPlus.onClick.AddListener(innerPlusHandler);
            rightInnerMinus.onClick.AddListener(innerMinusHandler);
            rightOuterPlus.onClick.AddListener(outerPlusHandler);
            rightOuterMinus.onClick.AddListener(outerMinusHandler);
            rightLowerPlus.onClick.AddListener(lowerPlusHandler);
            rightLowerMinus.onClick.AddListener(lowerMinusHandler);
            rightDropsPlus.onClick.AddListener(dropsPlusHandler);
            rightDropsMinus.onClick.AddListener(dropsMinusHandler);
            rightSubmit.onClick.AddListener(submit);
            rightUndo.onClick.AddListener(undo);
            rightNext.onClick.AddListener(next);

            rightAuton.onClick.AddListener(() => {
                isAuton = !isAuton;
                if(isAuton) {
                    rightAutonText.text = "Auton";
                    rightAuton.GetComponent<Image>().color = new Color(103f/255, 15f/255, 219f/255);
                } else {
                    rightAutonText.text = "Teleop";
                    rightAuton.GetComponent<Image>().color = new Color(231f/255, 151f/255, 1f/255);
                }
            });

            rightDefense.onClick.AddListener(() => {
                 if(defenseTimestamp == 0) {
                    defenseTimestamp = currentTime();
                    rightDefense.GetComponent<Image>().color = new Color(60f/255, 9f/255, 128f/255);
                } else {
                    Variables.currentLocation.defenseTime += currentTime() - defenseTimestamp;
                    defenseTimestamp = 0;
                    rightDefense.GetComponent<Image>().color = new Color(103f/255, 15f/255, 219f/255);
                }
            });

            rightBricked.onClick.AddListener(() => {
                 if(brickedTimestamp == 0) {
                    brickedTimestamp = currentTime();
                    rightBricked.GetComponent<Image>().color = new Color(60f/255, 9f/255, 128f/255);
                } else {
                    Variables.currentLocation.brickTime += currentTime() - brickedTimestamp;
                    brickedTimestamp = 0;
                    rightBricked.GetComponent<Image>().color = new Color(103f/255, 15f/255, 219f/255);
                }
            });
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
            if(Variables.currentLocation.side) {
                x = canvas.GetComponent<RectTransform>().rect.width - x;   
            } 
            x -= topLeft.x;
            y -= bottomRight.y;

            int cellX = (int)(x / cellSize);
            int cellY = (int)(y / cellSize);

            if(flipY)
                cellY = gridHeight - cellY - 1;
            if(cellX >= 15 || cellY >= 9) return;

            Debug.Log(cellX + ", " + cellY);

            setIconPosition(cellX, cellY);

            Variables.currentLocation.currentCycle.x = cellX;
            Variables.currentLocation.currentCycle.y = cellY;
            Variables.currentLocation.currentCycle.timestamp = currentTime() - startTimestamp;
        }   
    }

    void setIconPosition(int cellX, int cellY) {
        Vector3 cellCenter;
        if(flipY)
            cellY = gridHeight - cellY - 1;
        if(Variables.currentLocation.side) {
            cellCenter = new Vector3(canvas.GetComponent<RectTransform>().rect.width - (cellX + 0.5f) * cellSize - topLeft.x, (cellY + 0.5f) * cellSize + bottomRight.y / 1.1f, 10f) * canvas.scaleFactor;
        } else {
            cellCenter = new Vector3((cellX + 0.5f) * cellSize + topLeft.x, (cellY + 0.5f) * cellSize + bottomRight.y / 1.1f, 10f) * canvas.scaleFactor;
        }
        robot.rectTransform.sizeDelta = new Vector2(cellSize * 0.85f, cellSize * 0.85f);
        robot.transform.position = Camera.main.ScreenToWorldPoint(cellCenter);
        robot.enabled = true;
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

    void submit() {
        if(!robot.enabled) return;
        robot.enabled = false;
        if(isAuton) 
            Variables.currentLocation.autonCycles.Add(Variables.currentLocation.currentCycle);
        else
            Variables.currentLocation.teleopCycles.Add(Variables.currentLocation.currentCycle);
        Variables.currentLocation.currentCycle = new LocationData.Cycle();
    }

    void undo() {
        LocationData.Cycle undoCycle;
        if(Variables.currentLocation.teleopCycles.Count > 0) {
            undoCycle = Variables.currentLocation.teleopCycles[Variables.currentLocation.teleopCycles.Count - 1];
            Variables.currentLocation.teleopCycles.Remove(undoCycle);
        } else if(Variables.currentLocation.autonCycles.Count > 0) {
            undoCycle = Variables.currentLocation.autonCycles[Variables.currentLocation.autonCycles.Count - 1];
            Variables.currentLocation.autonCycles.Remove(undoCycle);
        } else 
            return;

        Variables.currentLocation.currentCycle = undoCycle;
        setIconPosition(undoCycle.x, undoCycle.y);
    }

    void next() {
        if(defenseTimestamp != 0) {
            Variables.currentLocation.defenseTime += currentTime() - defenseTimestamp;
        }
        SceneManager.LoadScene("Endgame");
    }
 
    static int currentTime() {
        return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    }
}
