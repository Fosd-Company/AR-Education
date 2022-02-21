using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MainUIThread : MonoBehaviour
{
    // ----------- Panels -----------
    [SerializeField]
    private ARSession Session;

    [SerializeField]
    private GameObject Interface_Panel;

    [SerializeField]
    private GameObject Credits_Panel;

    [SerializeField]
    private Canvas OriginCanvas;

    // ---------- UI ----------
    [SerializeField]
    private Button btn_Start;

    [SerializeField]
    private Button btn_Credits;

    [SerializeField]
    private Button btn_Quit;

    // ---------- Social ----------
    [SerializeField]
    private Button btn_fb;
    [SerializeField]
    private Button btn_inst;
    [SerializeField]
    private Button btn_tw;
    [SerializeField]
    private Button btn_page;

    private const string url_twitter = "https://twitter.com/Nic_ARTeam?s=09",
        url_mainpage = "https://nic-arteam.github.io/Nic-ARTeamPage/",
        url_facebook = "https://www.facebook.com/Nic-ARTeam-104434778692752/",
        url_instagram = "https://www.instagram.com/invites/contact/?i=90dpr5zv8p8w&utm_content=msqqklw";

    private void Awake()
    {
        // Hidding other panels
        Credits_Panel.gameObject.SetActive(false);

        // Fixing components
        Screen.orientation = ScreenOrientation.Portrait;

        // Adding Listeners
        AddListeners();
    }

    private void AddListeners()
    {
        // UI
        btn_Start.onClick.AddListener(StartSession);
        btn_Quit.onClick.AddListener(QuitInterface);
        btn_Credits.onClick.AddListener(ShowCredits);

        // Social
        btn_fb.onClick.AddListener(() => Application.OpenURL(url_facebook));
        btn_tw.onClick.AddListener(() => Application.OpenURL(url_twitter));
        btn_inst.onClick.AddListener(() => Application.OpenURL(url_instagram));
        btn_page.onClick.AddListener(() => Application.OpenURL(url_mainpage));
    }

    private void SwitchCanvasSession(bool trigger)
    {
        OriginCanvas.enabled =  trigger;
        Session.enabled = trigger;
    }

    private void StartSession()
    {
        Interface_Panel.gameObject.SetActive(false);
        SwitchCanvasSession(true);
    }

    private void OnEnable()
    {
        SwitchCanvasSession(false);
    }

    private void ShowCredits()
    {
        Interface_Panel.gameObject.SetActive(false);
        Credits_Panel.gameObject.SetActive(true);
    }

    void QuitInterface()
    {
        Application.Quit();
    }

        /// <summary>
    /// Show an Android toast message.
    /// </summary>
    /// <param name="message">Message string to show in the toast.</param>
    private static void ShowAndroidToastMessage(string message)
    {
#if UNITY_ANDROID
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            if (unityActivity == null) return;
            var toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                // Last parameter = length. Toast.LENGTH_LONG = 1
                using (var toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText",
                    unityActivity, message, 1))
                {
                    toastObject.Call("show");
                }
            }));
        }
#endif
    }
}
