using TMPro;
using UnityEngine;
using System.Collections;

public class GrillManager : MonoBehaviour
{
    public static GrillManager Instance;
    // 고기가 올라가야하는 위치를 담고 있음.
    public GameObject[] grillposes = new GameObject[4];
    // 올라간 고기 G.O
    public GameObject[] meats = new GameObject[4];
    public bool full;
    public GameObject nogrill;
    

    void Awake()
    {
        Instance = this;
    }
    public void AddMeat(GameObject meat)
    {
        full = true;
        for (int i = 0; i < meats.Length; i++)
        {

            if (meats[i] == null)
            {
                meats[i] = meat;
                meat.transform.position = grillposes[i].transform.position;
                meat.transform.parent = grillposes[i].transform;
                meat.GetComponent<Meat>().StartGrill();

                full = false;
                break;
            }

        }
           
    }

    public void RemoveMeat(GameObject meat)
    {
        for (int i = 0; i < meats.Length; i++)
        {
            if (meats[i] == meat)
            {
                meats[i] = null;
                break;
            }
        }
    }

    public void Nogirllmeat()
    {
        StartCoroutine(NoGrill());
    }

    IEnumerator NoGrill()
    {
        nogrill.SetActive(true);
        yield return new WaitForSeconds(1f);
        nogrill.SetActive(false);

    }

    public void RemoveAll ()
    {
       for(int i = 0; i < meats.Length; i++)
        {
            if(meats[i] != null)
            {
                Destroy(meats[i].gameObject);
                meats[i] = null;
            }
        }
    }
}
