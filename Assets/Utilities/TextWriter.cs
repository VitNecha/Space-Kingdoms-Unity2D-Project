using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private float timeInterval = 0.05f;
    private string fullText;
    private string currentText = "";
    int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        fullText = this.GetComponent<Text>().text.ToString();
        StartCoroutine(ShowText());
    }
    IEnumerator ShowText() {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i+1);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
