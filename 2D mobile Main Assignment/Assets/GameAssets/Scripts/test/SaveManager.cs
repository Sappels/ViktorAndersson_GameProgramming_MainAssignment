using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
class PlayerSaveData
{
    public string name;
    public int score;
}

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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Save(string data)
    {
        PlayerSaveData saveData = new PlayerSaveData();
        saveData.score = int.Parse(data);

        string jsonString = JsonUtility.ToJson(saveData);
        SaveToFirebase(jsonString);
    }

    public void SaveToFirebase(string data)
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        //puts the json data in the "users/userId" part of the database.
        Debug.Log("I got run");
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
