using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ClassSchedule : MonoBehaviour
{
    [Serializable]
    public class Course
    {
        public string location;
        public string course;
        public string days;
        public string time;
    }
    [SerializeField]
        public Course[] coursesData;

    [Serializable]
    public class ScheduleJsonData
    {
        public Course[] courses;

    }
    string[] locations = new string[3];
    void Start()
    {
        StartCoroutine(getData());
        
    }

    IEnumerator getData()
    {
        
        WWW www = new WWW("https://api.mocki.io/v1/6fe76739");
            yield return www;
        if (www.error == null)
        {
            ClassSchedule.ScheduleJsonData  json = JsonUtility.FromJson<ClassSchedule.ScheduleJsonData>(www.text);
            GameObject template = transform.GetChild(0).gameObject;
            GameObject g;
           
            for (int i = 0; i < 3; i++)
            {
                g = Instantiate(template, transform);
                g.transform.GetChild(0).GetComponent<Text>().text = json.courses[i].days;
                g.transform.GetChild(1).GetComponent<Text>().text = json.courses[i].time;
                g.transform.GetChild(2).GetComponent<Text>().text = json.courses[i].course;
                locations[i] = json.courses[i].location;
                g.GetComponent<Button>().onClick.AddListener(delegate ()
               {
                   ItemClicked(i);
               });
            }

            
            Destroy(template);
        }
        else
        {
            Debug.Log("Something went wrong while fetching Schedule data");
        }
    }

    void ItemClicked(int i)
    {
        if (i >= 3) i = 2;
        Debug.Log(locations[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
