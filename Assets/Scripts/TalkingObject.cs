using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogManament;

namespace InteractableObjects
{
	[RequireComponent(typeof(Dialogue))]
    public class TalkingObject : InteractableObject
	{
		public Dialogue m_dialogue;

		private void Start()
		{
			if(m_dialogue == null)
			{
				m_dialogue = GetComponent<Dialogue>();
			}
		}

		private void Update()
		{
			if(m_isInteractable)
			{
				if(Input.GetKeyDown(m_interactKey))
				{
					DialogManager.m_Singleton.startDialogue(m_dialogue);
				}
			}

			if (m_isInteractable && Input.GetKeyDown(KeyCode.F))
			{
				DialogManager.m_Singleton.endDialogue();
			}
		}
	}
}