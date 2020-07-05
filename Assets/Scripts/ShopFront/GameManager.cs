﻿using System.Collections;
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
		mTimerMessage = new Timer().SetTimer(0.0f).StartTimer();
	}
	
	private Timer mTimer;
	private Timer mTimerMessage;
	void Update ()
	{
		if(mTimer != null)
		{
			mTimer.Update();
			if(mTimer.TargetReached())
			{
				SF_NPC.GetScript().TableToDoor();
				SF_MainCharacterSmithy.GetScript().SetControl(true);
				mTimer = null;
			}
		}
		if(mTimerMessage != null)
		{
			mTimerMessage.Update();
			if(mTimerMessage.TargetReached())
			{
				if(StoryLive && SLItemID != -1)
				{
					TextChoice mTextChoice = getItemByID(SLItemID);
					if(SLItemID != mTextChoice.child[0])
					{
						SLItemID = mTextChoice.child[0];
						if(!mTextChoice.choicePick) {
							SendStoryMessage(mTextChoice.text, false, mTextChoice.id, false);
							mTimerMessage = new Timer().SetTimer(mTextChoice.text.Length * 0.05f).StartTimer();
							if(mTextChoice.exitRoom)
							{
								mTimer = new Timer().SetTimer(3.4f).StartTimer();
							}
						}
						if(mTextChoice.child.Capacity == 3)
						{
							TextChoice mTextChoice1 = getItemByID(mTextChoice.child[0]);
							TextChoice mTextChoice2 = getItemByID(mTextChoice.child[1]);
							TextChoice mTextChoice3 = getItemByID(mTextChoice.child[2]);
							SendStoryMessage(mTextChoice1.text, true, mTextChoice1.id, true);
							SendStoryMessage(mTextChoice2.text, true, mTextChoice2.id, true);
							SendStoryMessage(mTextChoice3.text, true, mTextChoice3.id, true);
							mTimerMessage = new Timer().SetTimer(0f).StartTimer();
							StoryLive = false;
						}
					} else {
						StoryLive = false;
					}
				}
			}
		}
	}

	public void OptionSelected(int msgID)
	{
		Destroy(storyPanel.transform.GetChild(messageList.Count - 1).gameObject);
		Destroy(storyPanel.transform.GetChild(messageList.Count - 2).gameObject);
		Destroy(storyPanel.transform.GetChild(messageList.Count - 3).gameObject);
		TextChoice mTextChoice = getItemByID(msgID);
		if(SLItemID <= mTextChoice.id && SLItemID >= 0)
		{
			SendStoryMessage(mTextChoice.text, false, mTextChoice.id, true);
			SLItemID = mTextChoice.child[0];
			StoryLive = true;
			if(mTextChoice.exitRoom)
			{
				SF_NPC.GetScript().TableToDoor();
			}
		}
	}

	public void ContinueStory()
	{
		if(StoryLive)
		{
			return;
		}
		StoryLive = true;
	}

	public void SendStoryMessage(string text, bool isChoice, int msgID, bool isColored)
	{
		Message mMessage = new Message();
		mMessage.text = text;

		GameObject newText = Instantiate(textObject, storyPanel.transform);
		mMessage.textObject = newText.GetComponent<Text>();
        mMessage.textObject.fontSize = 30;
		mMessage.textObject.text = mMessage.text;
		mMessage.textObject.name = "StoryLine_MSG_" + msgID;
        SF_Click mClick = (SF_Click)mMessage.textObject.GetComponent(typeof(SF_Click));
		mClick.setChoice(isChoice);

		if(isChoice)
		{
			mClick.SetID(msgID);
		}
		if(isColored)
		{
			mMessage.textObject.color = new Color(240.0f/255.0f, 76.0f/255.0f, 31.0f/255.0f);
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
	public bool exitRoom;
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
