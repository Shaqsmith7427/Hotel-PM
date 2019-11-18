using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwap_Controller : MonoBehaviour
{
    [SerializeField] string scene;

    /// <summary>
    /// When the player collides with this obj it will destroy the player
    /// (player is reloaded when next scene loads, player info IS NOT carried over)
    /// and will load the next scene (scene name is typed in as a string via the unity editor)
    /// </summary>
    /// <param name="other">
    /// "other" is the player colliding with this obj
    /// </param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Next level....");
        
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
