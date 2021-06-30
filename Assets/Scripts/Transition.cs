using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] string mainText;
    [SerializeField] Text mainTextObj;
    [SerializeField] string secondaryText;
    [SerializeField] Text secondaryTextObj;
    [SerializeField] bool typerEffect;
    [SerializeField] int nextSceneID;
    [SerializeField] float coolDownTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showText());
    }
    

    private IEnumerator showText() {
        if (typerEffect) { yield return typer(); }
        else mainTextObj.text = mainText;
        yield return new WaitForSeconds(coolDownTime);
        goToNextScene();
    }
    private IEnumerator typer()
    {
        for (int i = 0; i < this.mainText.Length; i++)
        {
            mainTextObj.text = mainText.Substring(0, i);
            yield return new WaitForSeconds(0.07f);
        }
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < this.secondaryText.Length; i++)
        {
            secondaryTextObj.text = secondaryText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void goToNextScene() { SceneManager.LoadScene(nextSceneID); }
    // Update is called once per frame
    void Update()
    {
        
    }
}
