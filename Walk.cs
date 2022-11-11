using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walk : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = ("•à”F" + GameSystem._walk); //GameSystem‚Å—p‚¢‚½•à”‚ğ‚Á‚Ä‚­‚é
    }
}