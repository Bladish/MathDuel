using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{

    public int[] RandomizeArr()
    {
        int[] arr = new int[5];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(1, 10);
        }
        return arr;
    }


}
