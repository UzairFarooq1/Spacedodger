using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitApp : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGame()
    {
        // Quit the game
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
