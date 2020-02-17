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
    private Texture2D[] textures;
    private int qrIndex;

    private int width = 600;
    private int height = 600;

    // Start is called before the first frame update
    void Start()
    {
        if(Constants.getRoleName() == "Location")
            textures = QRGenerator.generateQR(QRGenerator.getBinaryString(Variables.currentLocation), width, height);
        else
            textures = QRGenerator.generateQR(QRGenerator.getBinaryString(Variables.currentMatch), width, height);
        QRRawImage.rectTransform.sizeDelta = new Vector2(width, height);
        QRRawImage.texture = textures[qrIndex];

        InvokeRepeating("switchQR", 0, 1/4f);

        doneButton.onClick.AddListener(Done);
    }

    void switchQR() {
        QRRawImage.texture = textures[++qrIndex % textures.Length];
        qrIndex %= textures.Length;
    }

    void Done()
    {
       SceneManager.LoadScene("MainMenu");
    }  
}
