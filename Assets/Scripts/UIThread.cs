using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class UIThread : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Pipelines.RedirectData.prefabs = prefabs;
        Debug.Log("Prefabs loaded into Redirect Data");
    }

    public void LoadTrackingSession()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadAnchorSession()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
