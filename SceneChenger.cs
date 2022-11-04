using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChenger : MonoBehaviour
{
    void Update()
    {
        GameObject.Find("Walk").GetComponent<Text>().text = ("クリア歩数:" + GameSystem.Walk);
        if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync("Serect");
        }
    }
}
