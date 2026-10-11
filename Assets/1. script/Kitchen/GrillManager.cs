using TMPro;
using UnityEngine;
using System.Collections;

public class GrillManager : MonoBehaviour
{
    public static GrillManager Instance;
    public GameObject[] grillposes = new GameObject[4];
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
}
