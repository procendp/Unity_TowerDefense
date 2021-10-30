using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMover : MonoBehaviour
{
    public void GoGameScene()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        
        LoadingSceneController.LoadScene("GameScene");


        //LoadSceneMode.Additive 매개는 전에 있던 씬을 남긴다
    }
}
