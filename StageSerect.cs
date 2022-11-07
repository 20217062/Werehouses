using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSerect : MonoBehaviour
{
    int Serectnumber = 1;
    [SerializeField] int Uppernumber = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Serectnumber < Uppernumber)
            {
                Serectnumber += 1;
                GetComponent<Text>().text = Serectnumber.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Serectnumber > 1)
            {
                Serectnumber -= 1;
                GetComponent<Text>().text = Serectnumber.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync("Main_" + Serectnumber);
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