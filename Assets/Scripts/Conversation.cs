using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [SerializeField] Text character1Name;
    [SerializeField] Text character1TextObj;
    [SerializeField] Text character2Name;
    [SerializeField] Text character2TextObj;
    private string character1Text;
    private string character2Text;
    [SerializeField] Image character1Img;
    [SerializeField] Image character2Img;
    [SerializeField] Text[] optionButtonsText;
    [SerializeField] Button[] optionButtons;
    private string[] options;
    [SerializeField] ConversationState startingState;
    [SerializeField] Image character2TextBoxImgObj;
    [SerializeField] Image character2ImgBoxImgObj;
    ConversationState currentState;

    // Start is called before the first frame update
    void Start()
    {
        setCurrentState(startingState);
        //updateConversation();
    }

    public void setCharacter1Name() { this.character1Name.text = currentState.getCharacter1Name(); }
    public void setCharacter1Text() { this.character1Text = currentState.getCharacter1Text(); }
    public void setCharacter2Name() { this.character2Name.text = currentState.getCharacter2Name(); }
    public void setCharacter2Text() { this.character2Text = currentState.getCharacter2Text(); }
    public void setCharacter1Img() { this.character1Img.sprite = Resources.Load<Sprite>(currentState.getCharacter1Image()); }
    public void setCharacter2Img() { this.character2Img.sprite = Resources.Load<Sprite>(currentState.getCharacter2Image()); }
    public void setOption1ButtonText(string text) { this.options[0] = text; }
    public void setOption2ButtonText(string text) { this.options[1] = text; }
    public void setOption3ButtonText(string text) { this.options[2] = text; }
    public void setOption4ButtonText(string text) { this.options[3] = text; }
    public void setOptionButtonText(int buttonNumber, string text) { this.options[buttonNumber] = text; }
    public void setCurrentState(ConversationState state) {
        Debug.Log("=Setting New State +++++++++++++++");
        this.currentState = state;
        updateConversation();
    }

    public void updateConversation() {
        clearButons();
        setCharacter1Img();

        if (!currentState.character2IsActive()){
            character2ImgBoxImgObj.gameObject.SetActive(false);
            character2TextBoxImgObj.gameObject.SetActive(false);
        }

        options = new string[currentState.getNumberOfOptions()];
        setCharacter1Name();
        setCharacter1Text();
        setOptionButtonsText();
        StartCoroutine(show());
    }
    public void setOptionButtonsText() { 
        for (int i = 0; i < currentState.getNumberOfOptions(); i++) {
            setOptionButtonText(i, currentState.getOptionButtonText(i));
        }
    }
    
    public void setNewCurrentState(int stateIndex) { setCurrentState(currentState.GetConversationStates()[stateIndex]); }
    public void setNewCurrentState1() { setNewCurrentState(0); }
    public void setNewCurrentState2() { setNewCurrentState(1); }
    public void setNewCurrentState3() { setNewCurrentState(2); }
    public void setNewCurrentState4() { setNewCurrentState(3); }
    public void setNewCurrentStateNext() { setCurrentState(currentState.GetNextConversationText()); }

    IEnumerator dialogTyper(Text textObject, string text)
    {
        for (int i = 0; i < text.Length; i++) {
            textObject.text = text.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator showOptions() {
        for (int i = 0; i < options.Length; i++) {
            optionButtons[i].gameObject.SetActive(true);
            optionButtonsText[i].text = options[i];
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator show() {
        if (currentState.character1IsUpdated()) {
            yield return dialogTyper(character1TextObj, character1Text);
            //yield return new WaitForSeconds(0.4f);
        }
        if (currentState.character2IsActive()) {
            character2ImgBoxImgObj.gameObject.SetActive(true);
            character2TextBoxImgObj.gameObject.SetActive(true);
            if (currentState.character2IsUpdated()) {
                setCharacter2Name();
                setCharacter2Text();
                setCharacter2Img();
                
                yield return dialogTyper(character2TextObj, character2Text);
            }
        }
        else {
            character2ImgBoxImgObj.gameObject.SetActive(false);
            character2TextBoxImgObj.gameObject.SetActive(false);
        }

        yield return showOptions();
        
    }
    public void clearButons() {
        for (int i =0; i < optionButtons.Length; i++) {
            optionButtons[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
