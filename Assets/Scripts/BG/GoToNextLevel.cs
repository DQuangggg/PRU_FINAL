using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(++currentScene);
            Debug.Log(currentScene);
        }
    }
}
