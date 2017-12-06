using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNDragAndDropControl : MonoBehaviour
{


    public GameObject prefabAnswer;
    private GroupScratch g;
    public Transform parrentAnswer;
    public Transform parrentAnswer1;
    public Transform parrentAnswer2;
    public void InitDragAndDropData()
    {

        int chooseQuest = DataManagerCourse.Instance.dataQuestScratch.groupScratch.Count;
        g = DataManagerCourse.Instance.dataQuestScratch.groupScratch[Random.Range(0, chooseQuest)];

        Utils.RemoveAllChildren(parrentAnswer);
        Utils.RemoveAllChildren(parrentAnswer1);
        Utils.RemoveAllChildren(parrentAnswer2);
        foreach (Answer ans in g.answer)
        {

            GameObject obj = Instantiate(prefabAnswer, parrentAnswer);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.GetChild(0).GetComponent<Text>().text = ans.title;
            Canvas.ForceUpdateCanvases();
            DragAnswerElement dr = obj.GetComponent<DragAnswerElement>();
            dr.InitAnswer();
        }

    }
    public void OnClickDone() //Check Gmae
    {
        Debug.Log("Click Done");
        if (CheckAnswer(1))
        {

            ShowNextStep();

        }
        else
        {
            PanelPopUp.intance.OnInitInforPopUp("Opps!!", "Bạn chưa trả lời đúng. Vui lòng thử lại!! ");
        }

    }
    bool CheckAnswer(int chooseAns)
    {
        int d = 0;
        bool result = true;
        foreach (Transform tran in parrentAnswer)
        {
            DragAnswerElement dr = tran.GetComponent<DragAnswerElement>();
            if (dr.step != tran.GetSiblingIndex())
            {
                result = false;
            }
        }
        if (result)
            foreach (Transform tran in parrentAnswer1)
            {
                DragAnswerElement dr = tran.GetComponent<DragAnswerElement>();
                if (dr.step != tran.GetSiblingIndex() + parrentAnswer.childCount)
                {
                    result = false;
                }
            }
        if (result)
            foreach (Transform tran in parrentAnswer2)
            {
                DragAnswerElement dr = tran.GetComponent<DragAnswerElement>();
                if (dr.step != tran.GetSiblingIndex()+ parrentAnswer1.childCount+ parrentAnswer2.childCount)
                {
                    result = false;
                }
            }

        return result;

    }
    #region DragAndDropGame
    void ShowNextStep()
    {
        Debug.Log("Show Next Step");


    }
    #endregion
}
