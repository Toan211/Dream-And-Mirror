using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogManament
{
	public class DialogManager : MonoBehaviour
	{
		static public DialogManager m_Singleton;

		public GameObject m_dialogueBox;
		public TextMeshProUGUI m_speakerName;
		public TextMeshProUGUI m_speechContents;

		public GameObject m_interactNotification;
		public TextMeshProUGUI m_notifiedContents;

		public bool m_isDialoging = false;

		private void Awake()
		{
			if (m_Singleton == null)
			{
				m_Singleton = this;
			}
		}

		public void setDialog(string name, string contents)
		{
			this.m_speakerName.text = name;
			this.m_speechContents.text = contents;

			this.m_dialogueBox.SetActive(true);
		}

		public void endDialogue()
		{
			GameManager.m_Singleton.enableCharacterController();

			this.m_dialogueBox.SetActive(false);

			this.m_isDialoging = false;
		}

		public void startDialogue(Dialogue dialogue)
		{
			this.m_isDialoging = true;

			//Preventing player run around
			GameManager.m_Singleton.disableCharacterController();

			StartCoroutine(_startDialogue(dialogue));
		}

		IEnumerator _startDialogue(Dialogue dialogue)
		{
			//When this function is called, 
			//the "Press <key> to interact" isn't necessary anymore
			this.hideInteractNotification();

			m_dialogueBox.SetActive(true);

			int i = 0;
			while (i < dialogue.m_speeches.Length)
			{
				m_speakerName.text = dialogue.m_speeches[i].m_speaker;
				m_speechContents.text = dialogue.m_speeches[i].m_speech;

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