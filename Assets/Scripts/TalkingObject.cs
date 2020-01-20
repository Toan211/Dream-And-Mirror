using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogManament;

namespace InteractableObjects
{
	public class TalkingObject : InteractableObject
	{
		[SerializeField] public Dialogue m_dialogue;

		private void Update()
		{
			if(m_isInteractable)
			{
				if(Input.GetKeyDown(m_interactKey))
				{
					GameManager.m_Singleton.disableCharacterController();
					StartCoroutine(DialogManager.m_Singleton.startDialogue(m_dialogue));
				}
			}

			if (m_isInteractable && Input.GetKeyDown(KeyCode.F))
			{
				GameManager.m_Singleton.enableCharacterController();
				DialogManager.m_Singleton.closeDialogue();
			}
		}
	}
}