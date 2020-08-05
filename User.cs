using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class User : MonoBehaviour
{
    public string email;
    public string username;
    public string userId;
    public string userColorMode;
    public string isFirstTime;
    //public string[] userCategories = new string[4];
    public string userLanguage;
    public List<string> userNotifications = new List<string>();
    public List<Message> userChat = new List<Message>();
    public Dictionary<BotMessage, BotResponse> userChatHistory = new Dictionary<BotMessage, BotResponse>();
    public int coins;
    public string bio;
    public List<string> availableAvatars = new List<string>();
    public string currentAvatar;

    public User()
    {
        email = "";
        username = "";
        userId = "";
        userColorMode = "Normal";
        isFirstTime = "";
        userLanguage = "";
        coins = 0;
        bio = "";
    }
    public User(string email)
    {
        this.email = email;
    }
    public User(string email, string username, string userId, string userColorMode)
    {
        this.email = email;
        this.username = username;
        this.userId = userId;
        this.userColorMode = userColorMode;
    }
    public User(string email, string username, string userId, string userColorMode, string isFirstTime)
    {
        this.email = email;
        this.username = username;
        this.userId = userId;
        this.userColorMode = userColorMode;
        this.isFirstTime = isFirstTime;
    }
    //public User(string email, string username, string userId, string userColorMode, string userLanguage, string[] userCategories)
    //{
    //    this.email = email;
    //    this.username = username;
    //    this.userId = userId;
    //    this.userColorMode = userColorMode;
    //    this.userLanguage = userLanguage;
    //    for (int i = 0; i < userCategories.Length; i++)
    //    {
    //        this.userCategories[i] = userCategories[i];
    //    }
    //}
    public void DestroyMessageObjects()
    {
        for (int i = 0; i < userChat.Count; i++)
        {
            Destroy(userChat[i].textObject);
            userChat[i] = null;
        }
    }
}
