using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SessionThread : MonoBehaviour
{
    [SerializeField]
    private GameObject Interface_Panel;

    [SerializeField]
    public Button btn_Back;

    private void Awake()
    {
        btn_Back.onClick.AddListener(Back);
    }

    private void Back()
    {
        Interface_Panel.gameObject.SetActive(true);
    }
}
