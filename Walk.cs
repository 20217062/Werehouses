using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walk : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = ("歩数：" + GameSystem._walk); //GameSystemで用いた歩数を持ってくる
    }
}