using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RandomNamesForAi : MonoBehaviour
{
    public string namePlayerTwo;
    public string[] names;
    void Start()
    {
        AddNamesFromTextFile();
        RandomName();
    }

    public void AddNamesFromTextFile()
    {
        string path = "Assets/Resources/Names.txt";
        names = File.ReadAllLines(path);
    }

    public void RandomName()
    {
        namePlayerTwo = names[Random.Range(0, names.Length)];
    }
}
