using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class resetHS : MonoBehaviour
{
public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll(); // Deletes all saved player preferences
        PlayerPrefs.Save(); // Saves the changes

        Debug.Log("PlayerPrefs reset."); // Optional: Display a message in the console
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }
}
