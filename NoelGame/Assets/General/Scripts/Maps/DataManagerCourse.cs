using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;

public class DataManagerCourse : MonoSingleton<DataManagerCourse>
{

    public RootObjectQuestion data;

   public void LoadListQuestion()
    {
        string path = PathManager.ListQuest;
     
        try
        {
           // string asset = Utils.LoadTextFromFile(path);
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            if (textAsset == null)
                return;
            string asset = textAsset.text;
            if (string.IsNullOrEmpty(asset))
            {
                return;
            }
            data = JsonMapper.ToObject<RootObjectQuestion>(asset);
        }
        catch (Exception error)
        {
            Debug.LogError("Getting question Data error: " + error.StackTrace);
        }
    }





    //public void GetListCourseData()
    //{
    //    dataCourseQuestion = new List<DataCourseQuestion>();
    //    LoadCourse();
    //    int d = 0;

    //    foreach (ResultCourse data in dataCourse.result)
    //    {
    //        DataCourseQuestion course = new DataCourseQuestion();
    //        course.course = data;
    //        CourseQuestionAnswer c = new CourseQuestionAnswer();           
    //        c = LoadListAnswer(data.id);
    //        dataCourseQuestion.Add(course);
    //        dataCourseQuestion[d].listCourseAnswer.Add(c);

    //        d++;
    //    }
    //}

    //public CourseQuestionAnswer LoadListAnswer(int courseID)
    //{
    //    string path = PathManager.mInstance.CourseQuestionAnswer + courseID + ".json";

    //    try
    //    {
    //        string asset = Utils.LoadTextFromFile(path);
    //        CourseQuestionAnswer c = new CourseQuestionAnswer();
    //        c = JsonMapper.ToObject<CourseQuestionAnswer>(asset);
    //        return c;
    //    }
    //    catch (Exception error)
    //    {
    //        Debug.LogError("Getting course Data error: " + error.StackTrace);
    //        return null;
    //    }
    //}





}


[System.Serializable]
public class Answer
{
    public int answerID { get; set; }
    public string title { get; set; }
    public int sort { get; set; }
    public bool isCorrect { get; set; }
}
[System.Serializable]
public class Group
{
    public int questionID { get; set; }
    public string title { get; set; }
    public int sort { get; set; }
    public List<Answer> answer { get; set; }
}
[System.Serializable]
public class RootObjectQuestion
{
    public int CourseID { get; set; }
    public List<Group> group { get; set; }
}