using UnityEngine;

public class Toast
{
    /// <summary>
    /// Show an Android toast message.
    /// </summary>
    /// <param name="message">Message string to show in the toast.</param>
    public static void MakeText(string message)
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
