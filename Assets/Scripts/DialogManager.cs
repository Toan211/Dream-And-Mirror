using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogManament
{
	[System.Serializable]
	public class Speech
	{
		public string m_speaker;
		[TextArea(3, 5)] public string m_speech;
	}

	[System.Serializable]
	public class Dialogue
	{
		public Speech[] m_speeches;
	}

	public class DialogManager : MonoBehaviour
	{
		static public DialogManager m_Singleton;

		public GameObject m_dialogueBox;
		public TextMeshProUGUI m_name;
		public TextMeshProUGUI m_contents;

		public GameObject m_interactNotification;
		public TextMeshProUGUI m_notifiedContents;

		private void Awake()
		{
			if (m_Singleton == null)
			{
				m_Singleton = this;
			}
		}

		public void setDialog(string name, string contents)
		{
			this.m_name.text = name;
			this.m_contents.text = contents;

			this.m_dialogueBox.SetActive(true);
		}

		public void endDialogue()
		{
			GameManager.m_Singleton.enableCharacterController();

			this.m_dialogueBox.SetActive(false);
		}

		public IEnumerator startDialogue(Dialogue dialogue)
		{
			//Preventing player run around
			GameManager.m_Singleton.disableCharacterController();

			//When this function is called, 
			//the "Press <key> to interact" isn't necessary anymore
			this.hideInteractNotification();

			m_dialogueBox.SetActive(true);

			int i = 0;
			while (i < dialogue.m_speeches.Length)
			{
				m_name.text = dialogue.m_speeches[i].m_speaker;
				m_contents.text = dialogue.m_speeches[i].m_speech;

				yield return waitForInput(()=> Input.GetMouseButtonDown(0));

				i++;
			}

			this.endDialogue();
		}

		IEnumerator waitForInput(System.Func<bool> inputs)
		{
			bool isDone = false;

			while(!isDone)
			{
				if(inputs())
				{
					isDone = true;
				}
				yield return null;
			}
		}

		public void popUpInteractNotification(string content)
		{
			m_notifiedContents.text = content;
			m_interactNotification.SetActive(true);
		}

		public void hideInteractNotification()
		{
			m_interactNotification.SetActive(false);
		}
	}
}