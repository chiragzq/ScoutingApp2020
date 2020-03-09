// ArrayPrefs2 v 1.4
 
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
 
public class PlayerPrefsArray
{
static private int endianDiff1;
static private int endianDiff2;
static private int idx;
static private byte [] byteBlock;
 
enum ArrayType {Float, Int32, Bool, String, Vector2, Vector3, Quaternion, Color}
 
 
public static bool SetIntArray (String key, int[] intArray)
{
	return SetValue (key, intArray, ArrayType.Int32, 1, ConvertFromInt);
}

 
private static bool SetValue<T> (String key, T array, ArrayType arrayType, int vectorNumber, Action<T, byte[],int> convert) where T : IList
{
	var bytes = new byte[(4*array.Count)*vectorNumber + 1];
	bytes[0] = System.Convert.ToByte (arrayType);	// Identifier
	Initialize();
 
	for (var i = 0; i < array.Count; i++) {
		convert (array, bytes, i);	
	}
	return SaveBytes (key, bytes);
}
 
private static void ConvertFromInt (int[] array, byte[] bytes, int i)
{
	ConvertInt32ToBytes (array[i], bytes);
}
 
public static int[] GetIntArray (String key)
{
	var intList = new List<int>();
	GetValue (key, intList, ArrayType.Int32, 1, ConvertToInt);
	return intList.ToArray();
}
 
public static int[] GetIntArray (String key, int defaultValue, int defaultSize)
{
	if (PlayerPrefs.HasKey(key))
	{
		return GetIntArray(key);
	}
	var intArray = new int[defaultSize];
	for (int i=0; i<defaultSize; i++)
	{
		intArray[i] = defaultValue;
	}
	return intArray;
}
 
private static void GetValue<T> (String key, T list, ArrayType arrayType, int vectorNumber, Action<T, byte[]> convert) where T : IList
{
	if (PlayerPrefs.HasKey(key))
	{
		var bytes = System.Convert.FromBase64String (PlayerPrefs.GetString(key));
		if ((bytes.Length-1) % (vectorNumber*4) != 0)
		{
			Debug.LogError ("Corrupt preference file for " + key);
			return;
		}
		if ((ArrayType)bytes[0] != arrayType)
		{
			Debug.LogError (key + " is not a " + arrayType.ToString() + " array");
			return;
		}
		Initialize();
 
		var end = (bytes.Length-1) / (vectorNumber*4);
		for (var i = 0; i < end; i++)
		{
			convert (list, bytes);
		}
	}
}
 
private static void ConvertToInt (List<int> list, byte[] bytes)
{
	list.Add (ConvertBytesToInt32(bytes));
}
 
public static void ShowArrayType (String key)
{
	var bytes = System.Convert.FromBase64String (PlayerPrefs.GetString(key));
	if (bytes.Length > 0)
	{
		ArrayType arrayType = (ArrayType)bytes[0];
		Debug.Log (key + " is a " + arrayType.ToString() + " array");
	}
}
 
private static void Initialize ()
{
	if (System.BitConverter.IsLittleEndian)
	{
		endianDiff1 = 0;
		endianDiff2 = 0;
	}
	else
	{
		endianDiff1 = 3;
		endianDiff2 = 1;
	}
	if (byteBlock == null)
	{
		byteBlock = new byte[4];
	}
	idx = 1;
}
 
private static bool SaveBytes (String key, byte[] bytes)
{
	try
	{
		PlayerPrefs.SetString (key, System.Convert.ToBase64String (bytes));
	}
	catch
	{
		return false;
	}
	return true;
}
 
private static void ConvertInt32ToBytes (int i, byte[] bytes)
{
	byteBlock = System.BitConverter.GetBytes (i);
	ConvertTo4Bytes (bytes);
}
 
private static int ConvertBytesToInt32 (byte[] bytes)
{
	ConvertFrom4Bytes (bytes);
	return System.BitConverter.ToInt32 (byteBlock, 0);
}
 
private static void ConvertTo4Bytes (byte[] bytes)
{
	bytes[idx  ] = byteBlock[    endianDiff1];
	bytes[idx+1] = byteBlock[1 + endianDiff2];
	bytes[idx+2] = byteBlock[2 - endianDiff2];
	bytes[idx+3] = byteBlock[3 - endianDiff1];
	idx += 4;
}
 
private static void ConvertFrom4Bytes (byte[] bytes)
{
	byteBlock[    endianDiff1] = bytes[idx  ];
	byteBlock[1 + endianDiff2] = bytes[idx+1];
	byteBlock[2 - endianDiff2] = bytes[idx+2];
	byteBlock[3 - endianDiff1] = bytes[idx+3];
	idx += 4;
}
}