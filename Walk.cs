using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walk : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = ("ï‡êîÅF" + GameSystem.Walk);
    }
}