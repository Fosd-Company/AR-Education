using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class UIThread : MonoBehaviour
{
    private const string url_twitter = "https://twitter.com/Nic_ARTeam?s=09",
        url_mainpage = "https://nic-arteam.github.io/Nic-ARTeamPage/",
        url_facebook = "https://www.facebook.com/Nic-ARTeam-104434778692752/",
        url_instagram = "https://www.instagram.com/nic_arteam/?utm_medium=copy_link";

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Input.backButtonLeavesApp = true;
    }

    public void LoadTrackingSession()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void OpenFB() => Application.OpenURL(url_facebook);
    public void OpenWeb() => Application.OpenURL(url_mainpage);
    public void OpenTW() => Application.OpenURL(url_twitter);
    public void OpenIG() => Application.OpenURL(url_instagram);
}
