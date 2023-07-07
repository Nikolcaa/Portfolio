using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour
{
    [SerializeField] private string LinkUrl;

    public void OpenLink()
    {
        if (LinkUrl == System.String.Empty)
            LinkUrl = "https://play.google.com/store/apps/dev?id=7080821722793192096&hl=en&gl=US";

#if !UNITY_EDITOR
		openWindow(LinkUrl);
#else
        Application.OpenURL(LinkUrl);
#endif
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);

}