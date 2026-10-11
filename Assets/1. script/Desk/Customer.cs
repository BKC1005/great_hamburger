using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour
{
    public static Customer Instance;
    public float moveTime = 1f;

    void Awake()
    {
        Instance = this;
    }
    public void StartMove()
    {
        StartCoroutine(CustomerUp());
    }
    public void EndMove()
    {
        StartCoroutine(CustomerDown());
    }

    IEnumerator CustomerUp()
    {
        float t = 0f;

        Vector3 startPos = new Vector3(5, -7);
        Vector3 endPos = new Vector3(5, -1);

        transform.position = startPos;

        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;

            float speed = t * t;

            transform.position = Vector3.Lerp(startPos, endPos, speed);

            yield return null;
        }

        transform.position = endPos;
    }

    IEnumerator CustomerDown()
    {
        float t = 0f;

        Vector3 startPos = new Vector3(5, -1);
        Vector3 endPos = new Vector3(5, -7);

        transform.position = startPos;

        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;

            float speed = t * t;

            transform.position = Vector3.Lerp(startPos, endPos, speed);

            yield return null;
        }

        transform.position = endPos;

        Destroy(gameObject);
    }


}