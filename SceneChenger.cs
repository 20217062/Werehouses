using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChenger : MonoBehaviour
{
    void Update()
    {
        GameObject.Find("Walk").GetComponent<Text>().text = ("�N���A����:" + GameSystem._walk);
        if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync("Serect");
        }
    }
}
