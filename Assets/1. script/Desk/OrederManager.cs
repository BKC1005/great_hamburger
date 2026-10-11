using UnityEngine;
using TMPro;
using System.Collections;

public class OrederManager : MonoBehaviour
{
    public static OrederManager Instance;
    public GameObject customerPrefab;
    public TMP_Text orderText;
    public GameObject currentCustomer;
    public bool cus;
    public bool order;
    public OrederData[] orderDatas;
    public OrederData curOrderData;
    public GameObject yesnopanel;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        NewOrder();
    }

    public void NewOrder()
    {
        Debug.Log("1");

        currentCustomer = Instantiate(customerPrefab);

        Debug.Log("2");

        currentCustomer.transform.position = new Vector3(5, -7);

        Debug.Log("3");

        Customer customer = currentCustomer.GetComponent<Customer>();

        Debug.Log("4");

        customer.StartMove();

        Debug.Log("5");

        order = true;

        int random = Random.Range(0, orderDatas.Length);

        StartCoroutine(Wait());

        orderText.text = orderDatas[random].orderText;
        curOrderData = orderDatas[random];


    }
    public void Answer(bool good)
    {
        if (good)
        orderText.text = curOrderData.goodAnswer;
        else
            orderText.text = curOrderData.badAnswer;
    }
    public void Served(Hamburger hamburger)
    {
        yesnopanel.SetActive(false);
        StartCoroutine(CoWait());
        for (int i = 0; i < orderDatas.Length; i++)
        {
           // if()
           //curOrderData.ingredientNames
           //hamburger.ingredients
           // 햄버거 잘 만들었는지 계산           
        }
        Answer(true);
    }
    IEnumerator CoWait()
    {
        yield return new WaitForSeconds(2f); // 2초 기다리기
        Customer.Instance.EndMove();
        float sec = Random.Range(3,4);
        yield return new WaitForSeconds(sec);
        NewOrder();

    }
    public void AcceptOrder()
    {
        Debug.Log("주문을 받았습니다.");
    }

    public void RejectOrder()
    {
        Customer.Instance.EndMove();

        orderText.text = "";

        cus = true;

        StartCoroutine(NewCustomerWait());
    }

    
    IEnumerator NewCustomerWait()
    {
        yield return new WaitForSeconds(3f);

        NewOrder();

        cus = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);

        order = false;
    }
}
[System.Serializable]
public class OrederData
{
    public string orderText;

    public IngredientName[] ingredientNames;

    public MeatState meatState;

    public string goodAnswer;
    public string badAnswer;
}

