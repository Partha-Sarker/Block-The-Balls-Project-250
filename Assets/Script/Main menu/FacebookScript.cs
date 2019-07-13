using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using TMPro;
using System.Text;

public class FacebookScript : MonoBehaviour {

    public GameObject fbLoginButton;
    public GameObject fbPanel;
    public GameObject upButton;
    public GameObject downButton;
    public TextMeshProUGUI nameText;
    //private string email;
    //private DatabaseReference reference;

    public void Awake()
    {
        
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
        if (FB.IsInitialized && FB.IsLoggedIn) upButton.SetActive(true);
        
    }

    //void Start()
    //{
    //    Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
    //        var dependencyStatus = task.Result;
    //        if (dependencyStatus == Firebase.DependencyStatus.Available)
    //        {
    //            print("it may work!");
    //        }
    //        else
    //        {
    //            UnityEngine.Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
    //        }
    //    });
    //    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://block-the-balls.firebaseio.com/");
    //    reference = FirebaseDatabase.DefaultInstance.RootReference;
    //}

    public void FacebookLogin()
    {

        if (FB.IsLoggedIn && FB.IsInitialized)
        {
            if (nameText.text == "")
                nameText.text = "getting information";
                FB.API("me?fields=name,email", HttpMethod.GET, NameCallBack);
            fbLoginButton.SetActive(false);
            upButton.SetActive(false);
            fbPanel.SetActive(true);
            return;
        }
        var permissions = new List<string> { "public_profile", "email"};
        FB.LogInWithReadPermissions(permissions, AuthCallback);
        
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn && FB.IsInitialized)
        {
            if (nameText.text == "")
                nameText.text = "getting information";
                FB.API("me?fields=name,email", HttpMethod.GET, NameCallBack);
            fbLoginButton.SetActive(false);
            upButton.SetActive(false);
            fbPanel.SetActive(true);

        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    void NameCallBack(IGraphResult result)
    {
        var dict = Facebook.MiniJSON.Json.Deserialize(result.RawResult) as Dictionary<string, object>;
        string fbname = dict["name"].ToString();
        string email = dict["email"].ToString();
        string fireMail = fireEmail(email);
        int blocks = PlayerPrefs.GetInt("sumScore");
        //writeNewUser(fireMail, blocks, fbname);
        nameText.text = fbname;
    }

    //private void writeNewUser(string userId, int blocks, string fullName)
    //{
    //    User user = new User(blocks, fullName);
    //    string json = JsonUtility.ToJson(user);
    //    reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    //}

    public void hideFbPanel()
    {

        fbLoginButton.SetActive(true);
        fbPanel.SetActive(false);
        upButton.SetActive(true);
    }

    public void FacebookLogout()
    {
        FB.LogOut();
        fbLoginButton.SetActive(true);
        fbPanel.SetActive(false);
        upButton.SetActive(false);
    }

    private string fireEmail(string email)
    {
        int l = email.Length;
        StringBuilder sb = new StringBuilder(email);
        for (int i = 0; i < l; i++)
        {
            if (email[i] == '.') sb[i] = '*';
        }

        return sb.ToString();
    }

    private string normalEmail(string fireMail)
    {
        int l = fireMail.Length;
        StringBuilder sb = new StringBuilder(fireMail);
        for (int i = 0; i < l; i++)
        {
            if (fireMail[i] == '*') sb[i] = '.';
        }

        return sb.ToString();
    }

}
