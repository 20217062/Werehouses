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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//�����
        {
            if (_serectNumber < _upperNumber)
            {
                _serectNumber += 1;
                GetComponent<Text>().text = _serectNumber.ToString();//������1���������ăe�L�X�g�ɔ��f
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//������
        {
            if (_serectNumber > 1)
            {
                _serectNumber -= 1;
                GetComponent<Text>().text = _serectNumber.ToString();//������1���������ăe�L�X�g�ɔ��f
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadSceneAsync("Main_" + _serectNumber);//�X�y�[�X���͂ŃX�e�[�W�ؑ�
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//Esc���͂ŃQ�[���I��
            #else
                Application.Quit();//�Q�[���v���C�I��
            #endif
        }
    }
}