using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSerect : MonoBehaviour
{
    int _serectNumber = 1;
    [SerializeField] int _upperNumber = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_serectNumber < _upperNumber)
            {
                _serectNumber += 1;
                GetComponent<Text>().text = _serectNumber.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_serectNumber > 1)
            {
                _serectNumber -= 1;
                GetComponent<Text>().text = _serectNumber.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync("Main_" + _serectNumber);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
            #else
                Application.Quit();//ゲームプレイ終了
            #endif
        }
    }
}