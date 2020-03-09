using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;

public class QRGenerator
{
    private static Dictionary<string, string> charMap = new Dictionary<string, string> {
        {" ", "100"}, {",", "010"}, {".", "001"}, {"e", "1011"}, 
        {"t", "0001"}, {"a", "11111"}, {"o", "11100"}, {"n", "11010"}, 
        {"i", "11001"}, {"s", "10101"}, {"r", "10100"}, {"h", "01111"}, 
        {"d", "00001"}, {"l", "00000"}, {"u", "011101"}, {"c", "011100"}, 
        {"m", "011010"}, {"f", "011001"}, {"w", "011000"}, {"g", "1111011"}, 
        {"9", "1111010"}, {"2", "1111001"}, {"1", "1111000"}, {"4", "1110111"}, 
        {"3", "1110110"}, {"6", "1110101"}, {"5", "1110100"}, {"8", "1101111"}, 
        {"7", "1101110"}, {"0", "1101101"}, {"y", "1101100"}, {"p", "1100001"}, 
        {"b", "1100000"}, {"v", "0110110"}, {";", "11000101"}, {"(", "11000100"}, 
        {"-", "01101111"}, {"k", "01101110"}, {"?", "1100011100"}, {"!", "110001101"}, 
        {", ", "110001100"}, {"x", "11000111111"}, {"j", "11000111110"}, {"q", "11000111101"}, 
        {"z", "11000111100"}, {"%", "1100011101"}
    };

    public static Texture2D[] generateQR(String binary, int width, int height) {
        int QR_THRESHOLD = 400;
        int MAX_EXTRA_BITS = 25; // if the last qr is small, just append it to the previous

        int numQRs = Math.Min((int)(Math.Ceiling((double)binary.Length / QR_THRESHOLD)), 8);
        if(binary.Length % QR_THRESHOLD <= MAX_EXTRA_BITS) {
            numQRs--;
        }

        Debug.Log(binary);
        Debug.Log(binary.Length);
        Debug.Log(numQRs);

        Texture2D[] ret = new Texture2D[numQRs];

        int i = 0;
        for(;i < numQRs - 1;i ++) {
            ret[i] = generateBinaryTexture(ensureBits(i, 3) + ensureBits(numQRs - 1, 3) + binary.Substring(i * QR_THRESHOLD, QR_THRESHOLD), width, height);
        }
        ret[i] = generateBinaryTexture(ensureBits(i, 3) + ensureBits(numQRs - 1, 3) + binary.Substring(i * QR_THRESHOLD), width, height);

        return ret;
    }

    public static Texture2D generateBinaryTexture(String binary, int width, int height) {
        var hints = new Dictionary<EncodeHintType, object> { {EncodeHintType.MARGIN, 2} };
        BitMatrix bitMatrix = new MultiFormatWriter().encode(getByteString(binary), BarcodeFormat.QR_CODE, width, height, hints);
        Color[] pixels = new Color[bitMatrix.Width * bitMatrix.Height];
        int pos = 0;
        for (int y = 0; y < bitMatrix.Height; y++)
            for (int x = 0; x < bitMatrix.Width; x++)
                pixels[pos++] = bitMatrix[x, y] ? Color.black : Color.white;

        Texture2D texture = new Texture2D(width, height);
        texture.SetPixels(pixels);
        texture.Apply();
        return texture;
    }

    // Converts a string of 0s and 1s to their ascii equivalent
    public static string getByteString(string binaryString) {
        var list = new List<Byte>();
        Debug.Log(binaryString);
        for (int i = 0; i < binaryString.Length; i += 8) {
            String t = binaryString.Substring(i, Math.Min(8, binaryString.Length - i));
            if(t.Length < 8) {
                t += charMap["?"].Substring(0, 8 - t.Length);
            }
            list.Add(Convert.ToByte(t, 2));
        }  
        return Encoding.GetEncoding("ISO-8859-1").GetString(list.ToArray());
    }

    public static string getBinaryString(MatchData data)
    {
        string ret = "0" + ensureBits(data.teamIndex, 3);
        ret += ensureBits(data.matchNumber, 7);
        ret += ensureBits(Array.IndexOf(Constants.usernames, Constants.username), 6);

        ret += ensureBits(data.autonLower, 4);
        ret += ensureBits(data.autonOuter, 4);
        ret += ensureBits(data.autonInner, 4);

        ret += ensureBits(data.teleopLower, 6);
        ret += ensureBits(data.teleopOuter, 6);
        ret += ensureBits(data.teleopInner, 6);

        ret += ensureBits(Math.Min(127, data.brickTime), 7);
        ret += ensureBits(Math.Min(127, data.defenseTime), 7);

        ret += data.canSpin ? "1" : "0";
        ret += data.rotControl ? "1" : "0";
        ret += data.posControl ? "1" : "0";
        ret += data.initLine ? "1" : "0";

        ret += ensureBits(data.drops, 4);

        int climbData = 0; // 0 - 6, 0 & 1 mean park/climb, 2-6 represent a location along the bar of the climb
        if(data.climbType == 0) {
            climbData = 0;
        } else if(data.climbType == 1) {
            climbData = 1;
        } else {
            climbData = 2 + data.climbPos;
        }
        ret += ensureBits(climbData, 3);

        ret += data.ctrlPanelQuick ? "1" : "0";
        ret += data.ctrlPanelFirst ? "1" : "0";
        ret += data.robustClimb ? "1" : "0";
        ret += data.effectiveDefense ? "1" : "0";
        ret += data.goodDriver ? "1" : "0";
        ret += data.stableRobot ? "1" : "0";

        ret += convertText(data.offenseComments + "%");
        ret += convertText(data.generalComments);

        return ret;
    }

    public static string getBinaryString(LocationData data)
    {
        string ret = "1" + ensureBits(data.teamIndex, 3);
        ret += ensureBits(data.matchNumber, 7);
        ret += ensureBits(Array.IndexOf(Constants.usernames, Constants.username), 6);

        ret += ensureBits(data.autonCycles.Count, 2);
        foreach(LocationData.Cycle cycle in data.autonCycles) {
            ret += convertCycle(cycle);
        }

        ret += ensureBits(data.teleopCycles.Count, 5);
        foreach(LocationData.Cycle cycle in data.teleopCycles) {
            ret += convertCycle(cycle);
        }

        ret += ensureBits(Math.Min(127, data.brickTime), 7);
        ret += ensureBits(Math.Min(127, data.defenseTime), 7);

        ret += data.canSpin ? "1" : "0";
        ret += data.rotControl ? "1" : "0";
        ret += data.posControl ? "1" : "0";
        ret += data.initLine ? "1" : "0";

        int climbData = 0; // 0 - 6, 0 & 1 mean park/climb, 2-6 represent a location along the bar of the climb
        if(data.climbType == 0) {
            climbData = 0;
        } else if(data.climbType == 1) {
            climbData = 1;
        } else {
            climbData = 2 + data.climbPos;
        }
        ret += ensureBits(climbData, 3);

        ret += data.ctrlPanelQuick ? "1" : "0";
        ret += data.ctrlPanelFirst ? "1" : "0";
        ret += data.robustClimb ? "1" : "0";
        ret += data.effectiveDefense ? "1" : "0";
        ret += data.goodDriver ? "1" : "0";
        ret += data.stableRobot ? "1" : "0";

        ret += convertText(data.offenseComments + "%");
        ret += convertText(data.generalComments);

        return ret;
    }

    public static string convertCycle(LocationData.Cycle cycle) {
        return ensureBits(cycle.x, 4) +
            ensureBits(cycle.y, 3) +
            ensureBits(cycle.inner, 5) +
            ensureBits(cycle.outer, 5) +
            ensureBits(cycle.lower, 5) +
            ensureBits(cycle.drops, 5);
            
    }

    static string convertText(string text) {
        string ret = "";
        foreach(char s in text) {
            // string s2 = new string(s);
            if(charMap.ContainsKey(s.ToString())) {
                Debug.Log(charMap[s.ToString()]);
                ret += charMap[s.ToString()];
            }
        }
        return ret;
    }

    // converts a base 10 number to a base 2 number, ensuring the output is of a certain length.
    static string ensureBits(int val, int length) {
        string binary = Convert.ToString(val, 2);
        if(binary.Length < length) {
            while(binary.Length < length) binary = "0" + binary;
        } else if(binary.Length > length) {
            Debug.Log("Binary string exceeded max length of " + length + ": " + val + " / " + binary);
            binary = binary.Substring(binary.Length - length);
        }
        return binary;
    }
}
