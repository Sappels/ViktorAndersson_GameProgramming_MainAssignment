using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;

public class FirebaseTest : MonoBehaviour
{
    FirebaseAuth auth;

    public Button signInButton;
    public Button registerButton;
    public Button anonymousSignInButton;

    public TMP_InputField email;
    public TMP_InputField password;

    public TMP_Text currentUserText;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;
        });


        if (SceneManager.GetActiveScene().name == "FireBaseDemo")
        {
            signInButton.onClick.AddListener(() => { SignIn(email.text, password.text); });
            registerButton.onClick.AddListener(() => { RegisterNewUser(email.text, password.text); });
        }
    }

    public void AnonymousSignIn()
    {
        auth.SignInAnonymouslyAsync().ContinueWithOnMainThread(task => {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
                currentUserText.text = "Anonymous sign in failed: " + task.Exception.InnerExceptions[0].InnerException.Message;
            }
            else
            {
                SignedIn(task.Result);
                SceneManager.LoadScene(1);
            }
        });
    }

    public void RegisterNewUser(string email, string password)
    {
        Debug.Log("Starting Registration");
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
                currentUserText.text = "Could not register: " + task.Exception.InnerExceptions[0].InnerException.Message;
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User Registerd: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);

                SignedIn(newUser);
                SceneManager.LoadScene(1);
            }
        });
    }

    public void SignIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
                currentUserText.text = "Could not sign in: " + task.Exception.InnerExceptions[0].InnerException.Message;
            }
            else
            {
                SignedIn(task.Result);
                SceneManager.LoadScene(1);
            }
        });
    }

    private void SignedIn(FirebaseUser newUser) 
    {
        Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);

        //Display who logged in
        if (newUser.DisplayName != "")
            currentUserText.text = "Logged in as: " + newUser.DisplayName;
        else if (newUser.Email != "")
            currentUserText.text = "Logged in as: " + newUser.Email;
        else
            currentUserText.text = "Logged in as: Anon" + newUser.UserId.Substring(0, 6);
    }

    private void SignOut()
    {
        auth.SignOut();
        Debug.Log("User signed out");
    }

    private void SaveToFirebase(string data)
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        //puts the json data in the "users/userId" part of the database.
        db.RootReference.Child("users").Child(userId).SetRawJsonValueAsync(data);
    }

    private void LoadFromFirebase()
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        db.RootReference.Child("users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError(task.Exception);
            }

            //here we get the result from our database.
            DataSnapshot snap = task.Result;

            currentUserText.text = snap.GetRawJsonValue();

            //And send the json data to a function that can update our game.
            //LoadState(snap.GetRawJsonValue());

        });
    }

    private void DataTest(string userID, string data)
    {
        Debug.Log("Trying to write data...");
        var db = FirebaseDatabase.DefaultInstance;
        db.RootReference.Child("users").Child(userID).SetValueAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);
            else
                Debug.Log("DataTestWrite: Complete");
        });
    }
}
