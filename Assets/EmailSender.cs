using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailSender : MonoBehaviour
{
    [SerializeField] private Link _link;
    public void SendEmail()
    {
        string email = "nikolals05@outlook.com";
        string subject = MyEscapeURL("My Subject");
        string body = MyEscapeURL("My Body\r\nFull of non-escaped chars");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&amp;body=" + body);
    }

    string MyEscapeURL(string URL)
    {
        return WWW.EscapeURL(URL).Replace("+", "%20");
    }
}
