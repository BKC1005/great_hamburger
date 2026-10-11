using UnityEngine;

public class Meat : Ingredient
{
    public GameObject Meat1;
    public GameObject Meat2;
    public GameObject Meat3;
    public float cookTime = 5f;
    public float burnTime = 7f;
    public float time = 0f;
    public bool isGrill = false;

    public MeatState state;


    private void Start()
    {
        Meat1 = transform.Find("Meet1").gameObject;
        Meat2 = transform.Find("Meet2").gameObject;
        Meat3 = transform.Find("Meet3").gameObject;
    }
    public void StartGrill()
    {
        time = 0;
        isGrill = true;
        state = MeatState.Raw;
    }

    private void Update()
    {
        if (isGrill == true)
        {
            time += Time.deltaTime;

            if (time >= cookTime)
            {
                Cooked();
            }

            if (time >= burnTime)
            {
                Burned();
            }

            int index = Random.Range(0, 1);


        }
    }

    public void Cooked()
    {
        Meat1.SetActive(false);
        Meat2.SetActive(true);
        Meat3.SetActive(false);

        state = MeatState.Cooked;
    }

    public void Burned()
    {
        Meat1.SetActive(false);
        Meat2.SetActive(false);
        Meat3.SetActive(true);

        state = MeatState.Burned;
    }


}

public enum MeatState
{
    Raw,
    Cooked,
    Burned
}
