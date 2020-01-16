using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QR : MonoBehaviour
{
    public RawImage QRRawImage;
    public Button doneButton;

    private int width = Screen.height;
    private int height = Screen.height;

    // Start is called before the first frame update
    void Start()
    {
        QRRawImage.texture = QRGenerator.generateQR(Variables.currentMatch, width, height);
        QRRawImage.rectTransform.sizeDelta = new Vector2(width, height);

        doneButton.onClick.AddListener(Done);
    }

    void Done()
    {
       SceneManager.LoadScene("MainMenu"); 
    }  
}
