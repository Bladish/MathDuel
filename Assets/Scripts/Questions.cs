using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public static bool canRandomize;
    public static int rounds = 0;
    public static int[] Randomize()
    {
        int[] arr = new int[5];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(2, 10);    
        }
        canRandomize = false;
        rounds++;
        return arr;
    }
}
