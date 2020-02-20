using UnityEngine;
using UnityEngine.UI;

public class DataExchanger : MonoBehaviour
{
    public InputField fld;

    // a method which can be called from Android app
    public void ShowMessage(string message)
    {
        fld.text = message;
    }

    public void PassDataToAndroid()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        activity.CallStatic("setDataFromUnity", new object[] {fld.text});
    }
}