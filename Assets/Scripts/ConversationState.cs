using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ConversationState")]

public class ConversationState : ScriptableObject
{

    [SerializeField] string character1Name;
    [SerializeField] string character2Name;
    [SerializeField] string character1Text;
    [SerializeField] string character2Text;
    [SerializeField] bool character1Updated;
    [SerializeField] bool character2Active;
    [SerializeField] bool character2Updated;
    [SerializeField] string character1Img;
    [SerializeField] string character2Img;
    [SerializeField] string[] optionButtonsText;
    [SerializeField] ConversationState[] nextStates;
    [SerializeField] ConversationState nextState;

    public string getCharacter1Name() { return this.character1Name; }
    public string getCharacter1Text() { return this.character1Text; }
    public string getCharacter2Name() { return this.character2Name; }
    public string getCharacter2Text() { return this.character2Text; }
    public string getOptionButtonText(int optionButton) { return this.optionButtonsText[optionButton]; }
    public string[] getOptionButtonsText() { return this.optionButtonsText; }
    public int getNumberOfOptions() { return this.optionButtonsText.Length; }
    public bool character1IsUpdated() { return this.character1Updated; }
    public bool character2IsUpdated() { return this.character2Updated; }
    public bool character2IsActive() { return this.character2Active; }
    public string getCharacter1Image() { return this.character1Img; }
    public string getCharacter2Image() { return this.character2Img; }
    public ConversationState[] GetConversationStates() { return this.nextStates; }
    public ConversationState GetNextConversationText() { return this.nextState; }
}
 