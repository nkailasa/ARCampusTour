using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.IO;
using System.Globalization;
using UnityEngine.EventSystems;

public class AddNewClassScript : MonoBehaviour
{
    
   
        public InputField coursename;
        public InputField location;
        public InputField fromhrs;
        public InputField frommins;
        public InputField tohrs;
        public InputField tomins;
        public Toggle M;
        public Toggle T;
        public Toggle W;
        public Toggle Th;
        public Toggle F;
        public Toggle Sa;

    class MyCourse
    {
        public string coursename;
        public string location;
        public string fromtime;
        public string totime;
        public string days;
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator postData(string json)
    {
        UnityWebRequest www = UnityWebRequest.Post("https://api.mocki.io/v1/da06a1e8 ", json);
        Debug.Log(www);
        yield return www.SendWebRequest();
        Debug.Log(www);
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

        public void Save()
    {
        MyCourse myObject = new MyCourse();
        myObject.coursename = coursename.text;
        myObject.location = location.text;
        myObject.fromtime = ""+ fromhrs.text+ "" + frommins.text;
        myObject.totime = "" + tohrs.text + "" + tomins.text;
       
        Debug.Log(myObject.totime);
        string days = "";
        if (M.isOn) days += "M,";
        if (T.isOn) days += "T,";
        if (W.isOn) days += "W,";
        if (Th.isOn) days += "Th,";
        if (F.isOn) days += "F,";
        if (Sa.isOn) days += "Sa,";
        int len = days.Length;
        myObject.days = days.Substring(0, len - 1);
        string json = JsonUtility.ToJson(myObject);
        Debug.Log(json);
        postData(json);
       
    }
}
