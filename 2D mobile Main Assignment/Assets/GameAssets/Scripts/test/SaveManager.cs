using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public static SaveManager Instance { get { return instance; } }

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SaveToFirebase(string data)
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        //puts the json data in the "users/userId" part of the database.
        db.RootReference.Child("users").Child(userId).SetRawJsonValueAsync(data);
    }

    public void LoadFromFirebase()
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

            //And send the json data to a function that can update our game.
            //LoadState(snap.GetRawJsonValue());

        });
    }
}
