using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();

    public void AddIngredient(Ingredient ingredient)
    {
        ingredient.transform.parent = transform;
        ingredient.transform.position = transform.position + new Vector3(0, ingredients.Count * 0.1f);
        ingredients.Add(ingredient);
    }
    public void Clear()
    {
        for(int i = 0;i< ingredients.Count;i++)
        {
            Destroy(ingredients[i].gameObject);
        }
        ingredients.Clear();
    }
}


