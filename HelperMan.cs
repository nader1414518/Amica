using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;

public class HelperMan : MonoBehaviour
{
    public static bool reservationSent = false;

    public static void ShowPanel(GameObject panel)
    {
        if (panel)
        {
            panel.SetActive(true);
        }
    }
    public static void HidePanel(GameObject panel)
    {
        if (panel)
        {
            panel.SetActive(false);
        }
    }
    public static void HighlightPanel(GameObject panel)
    {
        if (panel)
        {
            Color color = panel.GetComponent<Image>().color;
            color.a = 1.0f;
            panel.GetComponent<Image>().color = color;
        }
    }
    public static void DehighlightPanel(GameObject panel)
    {
        if (panel)
        {
            Color color = panel.GetComponent<Image>().color;
            color.a = 0.0f;
            panel.GetComponent<Image>().color = color;
        }
    }
    public static void DestroyGameObjectList(List<GameObject> list)
    {
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i])
                {
                    Destroy(list[i]);
                }
            }
            list.Clear();
        }
    }
    public static bool CheckEmpty(InputField inputField)
    {
        if (inputField)
        {
            if (inputField.text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public static bool CheckNumeric(string str)
    {
        try
        {
            double.Parse(str);
            return true;
        }
        catch
        {
            Debug.Log("Enter a number please ... ");
            return false;
        }
    }
    public static void SendEmail(string msg, string topic, string destinationMail)
    {
        reservationSent = false;
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("amicabot413@gmail.com");
        mail.To.Add(new MailAddress(destinationMail));

        mail.Subject = topic;
        mail.Body = msg;


        SmtpServer.Credentials = new System.Net.NetworkCredential("amicabot413@gmail.com", "Amicabot314") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
        Debug.Log("Mail Sent ... ");
        reservationSent = true;
    }
    public static void CheckInternet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            MessageBox.Open("Check Internet Connection ... ");
        }
    }
    public static string GetBetween(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start, End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }

        return "";
    }
    public static string GetUnicode(string sourceString)
    {
        Encoding ascii = Encoding.ASCII;
        Encoding unicode = Encoding.Unicode;

        // get the ascii bytes array 
        byte[] asciiBytes = ascii.GetBytes(sourceString);

        // Perform the conversion from ascii to unicode
        byte[] unicodeBytes = Encoding.Convert(ascii, unicode, asciiBytes);

        // Convert the new byte[] into a char[] and then into a string
        char[] unicodeChars = new char[unicode.GetCharCount(unicodeBytes, 0, unicodeBytes.Length)];
        unicode.GetChars(unicodeBytes, 0, unicodeBytes.Length, unicodeChars, 0);
        string unicodeString = new string(unicodeChars);

        return unicodeString;
    }
    public static string GetUnicodeCharArray(string data)
    {
        string res = string.Empty;
        for (int i = 0; i < data.Length; i++)
        {
            if (i == 0)
            {
                res += char.ConvertToUtf32(data, i).ToString("X");
            }
            else
            {
                res += "," + char.ConvertToUtf32(data, i).ToString("X");
            }
        }
        return res;
    }
    public static string FindLang(string text)
    {
        string result = "";
        if (text.Any(c => c >= 0xFB50 && c <= 0xFEFC) || text.Any(c => c >= 0x0600 && c <= 0x06FF))
        {
            result += "Arabic";
        }
        //if (text.Any(c => c >= 0x0600 && c <= 0x06FF))
        //{
        //    result += "Persian";
        //}
        else if (text.Any(c => c >= 0x20 && c <= 0x7E))
        {
            result += "English";
        }
        //if (text.Any(c => c >= 0x0530 && c <= 0x058F))
        //{
        //    result += "Armenian";
        //}
        //if (text.Any(c => c >= 0x2000 && c <= 0xFA2D))
        //{
        //    result += "Chinese";
        //}
        return result;
    }
    public static string FindScalars(string response)
    {
        string res = string.Empty;
        string temp = response;
        List<int> locs = new List<int>();
        List<string> syll = new List<string>();

        // Determine the locations of commas in the string 
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] == ',')
            {
                locs.Add(i);
            }
        }

        // Cut Every Syllabus based on the locations of commas 
        for (int j = 0; j < locs.Count; j++)
        {
            if (j == 0)
            {
                syll.Add(temp.Substring(0, temp.IndexOf(",")).Replace(",", ""));
            }
            else
            {
                syll.Add(temp.Substring(locs[j - 1] + 1, temp.IndexOf(",")).Replace(",", ""));
            }
        }

        foreach (string snap in syll)
        {
            res += char.ConvertFromUtf32(int.Parse(snap, NumberStyles.HexNumber));
        }

        return res;
    }
}
