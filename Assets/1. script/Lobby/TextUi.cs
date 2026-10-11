using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextUi : MonoBehaviour
{
    public float moveTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        StartCoroutine(Right());
    }

    // Update is called once per frame
    IEnumerator Right()
    {
        float t = 0f;

        Vector3 startPos = new Vector3(-4.67f, -2.53f);
        Vector3 endPos = new Vector3(1.34f, -2.53f);

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

    public void Button()
    {
        SceneManager.LoadScene("InGame");
    }
}
