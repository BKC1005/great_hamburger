using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    public static KitchenManager Instance;

    public GameObject breadPrefab;
    public GameObject meatPrefab;
    public Transform domaTr;
    public Transform grill;
    public float howmuchIngredient = 0;
    public int grillonM = 0;
    public Hamburger hamburger;
    public Transform kitchenTr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        StartKitchen();        
    }

    void OnDisable()
    {
        // hamburger.gameObject.SetActive(false);
    }

    public void StartKitchen()
    {
        Debug.Log("Kitchen<anager OnEnable()");
        hamburger.Clear();
        GrillManager.Instance.RemoveAll();
        hamburger.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //Screen -> World 좌표계로 치환
            Collider2D collider2D = Physics2D.OverlapPoint(worldPos);
            if (collider2D == null)
                return;

            Meat meat1 = collider2D.GetComponentInParent<Meat>();

            if (meat1 != null && meat1.isGrill)
            {

                GrillManager.Instance.RemoveMeat(meat1.gameObject);
                meat1.isGrill = false;
                hamburger.AddIngredient(meat1);
                return;
            }
            IngredientContainer ingredientContainer = collider2D.GetComponent<IngredientContainer>();
            if(ingredientContainer != null)
            {
                if (ingredientContainer.ingredientName == IngredientName.Bread)
                {                    
                    GameObject bread = Instantiate(breadPrefab, kitchenTr);

                    hamburger.AddIngredient(bread.GetComponent<Ingredient>());
                    
                }
                if (ingredientContainer.ingredientName == IngredientName.Meat)
                {
                    // howmuchIngredient += 1;
                    for(int i = 0; i < GrillManager.Instance.meats.Length; i++)
                    {
                        if (GrillManager.Instance.meats[i] == null)
                        {
                            GameObject meat = Instantiate(meatPrefab, kitchenTr);
                            GrillManager.Instance.AddMeat(meat);
                            break;
                        }

                        if (i == 3)
                        {
                            GrillManager.Instance.Nogirllmeat();
                        }
                    }
                    
                    
                    //GrillManager의 AddMeat(bread)
                }
            }
        }
        
    }
}
