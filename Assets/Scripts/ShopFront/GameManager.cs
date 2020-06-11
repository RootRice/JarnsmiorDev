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
		if(StoryLive) {
			TextChoice mTextChoice = getItemByID(SLItemID);
			if(SLItemID != mTextChoice.child[0]) {
				SLItemID = mTextChoice.child[0];
				SendStoryMessage(mTextChoice.text);
			} else {
				StoryLive = false;
			}
		}
	}

	public void ContinueStory()
	{
		if(StoryLive) {
			return;
		}
		StoryLive = true;
	}

	public void SendStoryMessage(string text)
	{
		Message mMessage = new Message();
		mMessage.text = text;

		GameObject newText = Instantiate(textObject, storyPanel.transform);
		mMessage.textObject = newText.GetComponent<Text>();
		mMessage.textObject.text = mMessage.text;

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
