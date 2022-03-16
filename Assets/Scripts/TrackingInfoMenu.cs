using UnityEngine;
using UnityEngine.SceneManagement;
using Pipelines;

public class TrackingInfoMenu : MonoBehaviour
{
    public GameObject InfoMenu;
    private InfoPanel infoPanel;
    
    void Awake()
    {
        if (InfoMenu != null)
            infoPanel = new InfoPanel(InfoMenu);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadInfoData()
    {
        // Expected to be set by toast events
        if (infoPanel != null)
            infoPanel.SetInfo(RedirectData.targetSprite, RedirectData.targetModel);
    }
}
