using System.Collections;
using UnityEngine;

public class Logomove : MonoBehaviour
{
    public float moveTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        StartCoroutine(Down());
    }

    // Update is called once per frame
    IEnumerator Down()
    {
        float t = 0f;

        Vector3 startPos = new Vector3(-3.5f, 10);
        Vector3 endPos = new Vector3(-3.5f, 2);

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
}
