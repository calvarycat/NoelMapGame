using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlQuestion : MonoBehaviour
{

    public GameObject Root;
    public Transform parrentAnswer;
    public GameObject Answer;
    public Text txtQuestion;

    void Start()
    {
        DataManagerCourse.Instance.LoadListQuestion();
        Debug.Log(DataManagerCourse.Instance.data.group.Count);
        ShowQuest();
        Init(0);

    }

    public void ShowQuest()
    {

        Root.gameObject.SetActive(true);
    }
    public void Init(int questID)
    {

        Group g = DataManagerCourse.Instance.data.group[0];
        SessionQuestAnswer q = new SessionQuestAnswer();
        q.answer = -1;
        q.quest = g; // thay bang cách lay dữ liệu from data layer
        Utils.RemoveAllChildren(parrentAnswer);

        txtQuestion.text = g.title;
        int LableAnswer = 0;
        foreach (Answer ans in g.answer)
        {

            GameObject obj = Instantiate(Answer, parrentAnswer);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;
            AnswerInit ani = obj.GetComponent<AnswerInit>();
            ani.Init(GetLableAnswer(LableAnswer), ans.title);
            int answerChoose = LableAnswer;
            ani.GetComponentInChildren<Button>().onClick.AddListener(delegate { OnClickAnswer(answerChoose, ans.title); });
            LableAnswer++;
        }
    }
    void OnClickAnswer(int asn, string answer)
    {
        Debug.Log(asn + answer);
    }
    public string GetLableAnswer(int lab)
    {
        string rs = "N";
        switch (lab)
        {
            case 0:
                rs = "A";
                break;
            case 1:
                rs = "B";
                break;
            case 2:
                rs = "C";
                break;
            case 3:
                rs = "D";
                break;
            case 4:
                rs = "E";
                break;
            case 5:
                rs = "F";
                break;
        }
        return rs;

    }
    public List<SessionQuestAnswer> curentSessionQuestList;
    public void StartSessionQuest()
    {
        curentSessionQuestList = new List<SessionQuestAnswer>();
    }

    public void AddQuest(SessionQuestAnswer quest)
    {
        curentSessionQuestList.Add(quest);
    }
    public void NextQuest()
    {

    }
}
public class SessionQuestAnswer
{
    public int answer = -1;
    public Group quest;

}
