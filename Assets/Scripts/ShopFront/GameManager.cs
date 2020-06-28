using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour {

	public GameObject storyPanel, textObject;
	[SerializeField]
	List<Message> messageList = new List<Message>();
    private TextChoices textValues;
	private bool StoryLive = false;
    private int SLItemID = 0;

	void Start () {
        string path = "Assets/JSON/story.json";
        string contents = File.ReadAllText(path);
        textValues = JsonUtility.FromJson<TextChoices>(contents); 
	}
	
	void Update () {
		if(StoryLive && SLItemID != -1) {
			TextChoice mTextChoice = getItemByID(SLItemID);
			if(SLItemID != mTextChoice.child[0]) {
				SLItemID = mTextChoice.child[0];
				if(!mTextChoice.choicePick) {
					SendStoryMessage(mTextChoice.text, false, mTextChoice.id);
				}
				if(mTextChoice.child.Capacity == 3) {
                    TextChoice mTextChoice1 = getItemByID(mTextChoice.child[0]);
                    TextChoice mTextChoice2 = getItemByID(mTextChoice.child[1]);
                    TextChoice mTextChoice3 = getItemByID(mTextChoice.child[2]);
					SendStoryMessage(mTextChoice1.text, true, mTextChoice1.id);
					SendStoryMessage(mTextChoice2.text, true, mTextChoice2.id);
					SendStoryMessage(mTextChoice3.text, true, mTextChoice3.id);
					StoryLive = false;
				}
			} else {
				StoryLive = false;
			}
		}
	}

	public void OptionSelected(int msgID)
	{
		TextChoice mTextChoice = getItemByID(msgID);
		if(SLItemID <= mTextChoice.id && SLItemID >= 0)
		{
			SendStoryMessage(mTextChoice.text, false, mTextChoice.id);
			SLItemID = mTextChoice.child[0];
			StoryLive = true;
		}
	}

	public void ContinueStory()
	{
		if(StoryLive) {
			return;
		}
		StoryLive = true;
	}

	public void SendStoryMessage(string text, bool isChoice, int msgID)
	{
		Message mMessage = new Message();
		mMessage.text = text;

		GameObject newText = Instantiate(textObject, storyPanel.transform);
		mMessage.textObject = newText.GetComponent<Text>();
		mMessage.textObject.text = mMessage.text;
		mMessage.textObject.name = "StoryLine_MSG_" + msgID;
        SF_Click mClick = (SF_Click)mMessage.textObject.GetComponent(typeof(SF_Click));
		mClick.setChoice(isChoice);

		if(isChoice) {
			mMessage.textObject.color = new Color(240.0f/255.0f, 76.0f/255.0f, 31.0f/255.0f);
			mClick.SetID(msgID);
		}

		messageList.Add(mMessage);
	}

    TextChoice getItemByID(int id)
    {
        bool found = false;
        int i = 0;
        while(!found && i<textValues.story_line.Capacity)
        {
            if(textValues.story_line[i].id == id)
            {
                found = true;
            }
            else
            {
                i++;
            }
        }
        return textValues.story_line[i];
    }

}

[System.Serializable]
public class TextChoice
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public int id;
    public string text;
    public List<int> child;
    public int choice = -1;
    public bool choicePick;
}

[System.Serializable]
public class TextChoices
{
    public List<TextChoice> story_line;
}

[System.Serializable]
public class Message
{
	public string text;
	public Text textObject;
}
