using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDissappear : MonoBehaviour
{
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }
}
