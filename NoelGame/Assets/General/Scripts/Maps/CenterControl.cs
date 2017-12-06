using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CenterControl : MonoBehaviour
{

    private OnlineMaps _api;
    public GameObject Root;
    public PnInCenter pnInCenter;
    // Use this for initialization
    private OnlineMapsMarker _searchMarker;
    public GameObject pnButtonCenter;
    public Transform parentPnbuttonCenter;
    Vector2 curentPosition;
    public int ChooseCenter = -1;
    void Start()
    {
        _api = OnlineMaps.instance;
        Invoke("ViewCurrentPosition", .5f);
    }
    public void OnShow(bool _isShow)
    {
        Root.gameObject.SetActive(_isShow);
    }
    void ViewCurrentPosition()
    {
        curentPosition = OnlineMapsLocationService.instance.position;
        if (curentPosition != Vector2.zero)
        {
            StartCoroutine(Init());
        }
        else
        {
            Invoke("ViewCurrentPosition", .5f);
        }

    }

    public IEnumerator Init()
    {
        Vector2 position = OnlineMapsLocationService.instance.position;
        Utils.RemoveAllChildren(parentPnbuttonCenter);
        for (int i = 0; i < 5; i++)
        {
            UpdateDistant(i, curentPosition);
        }
        yield return null;
    }
    public void OnClickChooseCenter()
    {
        if(ChooseCenter!=-1)
        {
            Root.gameObject.SetActive(false);
            pnInCenter.InitCenter(ChooseCenter);
            Debug.Log("Ban da chon center " + ChooseCenter);
        }else
        {
            Debug.Log("Please Choose a center");
        }
       
    }
    public void OncenterClick(int id)
    {
        Vector2 position = Datacenter.instance.listCenter[id].pos;
        if (position != Vector2.zero)
        {
            if (_searchMarker == null)
            {
                _searchMarker = _api.AddMarker(position);
            }
            else
            {
                _searchMarker.position = position;
                _searchMarker.label = "center Localtion";
            }

            if (_api.zoom < 10)
                _api.zoom = 10;

            _api.position = position;
            _api.Redraw();
            ChooseCenter = id;
        }else
        {
            Debug.Log("Please Open services");
        }
    }
    public void CheckInTheCenter(Vector2 yourPos, int centerID)
    {
        OnlineMapsGoogleDirections query
            = OnlineMapsGoogleDirections.Find(yourPos, Datacenter.instance.listCenter[centerID].pos);
        query.OnComplete += CheckKC;
    }
    bool isIn;
    void CheckKC(string response)
    {
        int kc = 0;
        List<OnlineMapsDirectionStep> steps = OnlineMapsDirectionStep.TryParse(response);
        if (steps != null)
        {
            kc = CaculateeKHoangCach(steps);
            if (kc < 5)
            {
                isIn = true;
            }
        }

    }


    void UpdateDistant(int i, Vector2 pos)
    {
        OnlineMapsGoogleDirections query
            = OnlineMapsGoogleDirections.Find(OnlineMapsLocationService.instance.position, Datacenter.instance.listCenter[i].pos);
        query.OnComplete += OnDistanFindComplete;
    }
    int kc;
    int initCounter = 0;
    void OnDistanFindComplete(string response)
    {
        List<OnlineMapsDirectionStep> steps = OnlineMapsDirectionStep.TryParse(response);
        if (steps != null)
        {
            kc = CaculateeKHoangCach(steps);

        }
        int c = initCounter;
        GameObject obj = Instantiate(pnButtonCenter, parentPnbuttonCenter);
        BtnCenter bt = obj.GetComponent<BtnCenter>();
        bt.Init(initCounter, Datacenter.instance.listCenter[initCounter].name, kc);
        obj.transform.localScale = new Vector3(1, 1, 1);
        bt.GetComponentInChildren<Button>().onClick.AddListener(delegate { OncenterClick(c); });


        bt.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { GotoCenter(c); });

        initCounter++;
        Sort();
    }

    public void GotoCenter(int centerID)
    {
        if (centerID != -1)
        {
            Root.gameObject.SetActive(false);
            pnInCenter.InitCenter(centerID);
            Debug.Log("Ban da chon center " + centerID);
        }
       
    }
    public List<BtnCenter> SortedList;
    int ix;
    public void Sort()
    {
        List<BtnCenter> listBtn = new List<BtnCenter>();
        foreach (Transform tran in parentPnbuttonCenter.transform)
        {
            BtnCenter bt = tran.GetComponent<BtnCenter>();
            int value = bt.distant;          
            listBtn.Add(bt);
        }
        SortedList = listBtn.OrderBy(o => o.distant).ToList();
        ix = 0;
        foreach (BtnCenter tran in SortedList)
        {
            tran.transform.SetSiblingIndex(ix);
            ix++;
        }
    }
    public int CaculateeKHoangCach(List<OnlineMapsDirectionStep> _routes)
    {
        int rs = 0;
        for (int i = 0; i < _routes.Count; i++)
        {
            rs += _routes[i].distance;
        }
        return rs;
    }
}
[System.Serializable]
public class PositionWELCenter
{
    public string name = "Default";
    public Vector2 pos = Vector2.zero;
    public string Address = "";
}