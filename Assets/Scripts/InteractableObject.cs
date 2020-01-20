using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogManament;

namespace InteractableObjects
{
	//Base class
	[RequireComponent(typeof(Collider2D))]
	public class InteractableObject : MonoBehaviour
    {
        public KeyCode m_interactKey;
        protected bool m_isInteractable = false;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.GetComponent<PlayerControl>())
			{
				m_isInteractable = true;

				string noti = "Press " + m_interactKey + " to interact!";
				DialogManager.m_Singleton.popUpInteractNotification(noti);
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.gameObject.GetComponent<PlayerControl>())
			{
				m_isInteractable = false;
				DialogManager.m_Singleton.hideInteractNotification();
			}
		}
	}
}
