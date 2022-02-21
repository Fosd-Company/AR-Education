using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class SessionThread : MonoBehaviour
{
    private void Awake()
    {
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
