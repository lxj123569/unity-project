using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiaoZhuang : MonoBehaviour
{
    public int sceneIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        changeScene();
    }
    public void changeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
