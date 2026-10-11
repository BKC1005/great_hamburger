using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject deskLay;
    public GameObject kitchenLay;


    public void StartDesk()
    {
        deskLay.SetActive(true);
        OrederManager.Instance.Served(KitchenManager.Instance.hamburger);
        kitchenLay.SetActive(false);
    }
    public void StartKitchen()
    {
        deskLay.SetActive(false);
        kitchenLay.SetActive(true);
    }
}
