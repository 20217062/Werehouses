using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSerect : MonoBehaviour
{
    int SerectNumber = 1;
    [SerializeField] int UpperNumber = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (SerectNumber < UpperNumber)
            {
                SerectNumber += 1;
                GetComponent<Text>().text = SerectNumber.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (SerectNumber > 1)
            {
                SerectNumber -= 1;
                GetComponent<Text>().text = SerectNumber.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync("Main_" + SerectNumber);
        }
    }
}