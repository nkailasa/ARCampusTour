using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Studentdatabase : MonoBehaviour
{

    DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {

            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));

            }
        });


        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("");

        FirebaseDatabase.DefaultInstance.GetReference("Leader").GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted)
        {

        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            void HandleValueChanged(object sender, ValueChangedEventArgs args)
            {
                if (args.DatabaseError != null)
                {
                    Debug.LogError(args.DatabaseError.Message);
                    return;

                }
            });


        reference = FirebaseDatabase.DefaultInstance.RootReference;




        string DebugMsg = saveDataToFirebase(002, "Michael Findler", "SER515", "T,Th", "10:30 A.M.", "PICHO Hall" { 33.3063536,-111.68145},"Faculty");
        string data1 = saveDataToFirebase(014, "Kanti", "SER501", "T,Th", "02:30 P.M.", "PICHO Hall", { 33.3063536,-111.68145},"Student");
        string data2 = saveDataToFirebase(014, "Nevedita", "SER515", "T,Th", "10:30 A.M.", "PICHO Hall", { 33.3063536,-111.68145},"Student");
        Debug.Log(DebugMsg); // print message in console

    }

    public string saveDataToFirebase(int id, string name, string course, string days, String time, string location, double coordinates[], string userType)
    {
        reference.Child(id.ToString()).Child("Name").SetValueAsync(name);
        reference.Child(id.ToString()).Child("Course").SetValueAsync(course);
        reference.Child(id.ToString()).Child("Days").SetValueAsync(days);
        reference.Child(id.ToString()).Child("Time").SetValueAsync(time);
        reference.Child(id.ToString()).Child("Location").SetValueAsync(location);
        reference.Child(id.ToString()).Child("Coordinates").SetValueAsync(coordinates);
        reference.Child(id.ToString()).Child("User type").SetValueAsync(userType);
        return "Save data to firebase Done.";
    }
}
