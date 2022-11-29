using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSerect : MonoBehaviour
{
    int _serectNumber = 1;
    [SerializeField] int _upperNumber = 10;
    private void Awake() {
        GameSystem._walk = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上入力
        {
            if (_serectNumber < _upperNumber)
            {
                _serectNumber += 1;
                GetComponent<Text>().text = _serectNumber.ToString();//数字を1増加させてテキストに反映
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下入力
        {
            if (_serectNumber > 1)
            {
                _serectNumber -= 1;
                GetComponent<Text>().text = _serectNumber.ToString();//数字を1減少させてテキストに反映
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadSceneAsync("Main_" + _serectNumber);//スペース入力でステージ切替
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//Esc入力でゲーム終了
            #else
                Application.Quit();//ゲームプレイ終了
            #endif
        }
    }
}