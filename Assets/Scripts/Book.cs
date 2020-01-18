using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
	[TextArea(3,5)] public string m_contents;

	private bool m_interactable = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.GetComponent<PlayerControl>())
			m_interactable = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerControl>())
			m_interactable = false;
	}

	private void Update()
	{
		if(m_interactable && Input.GetKeyDown(KeyCode.E))
		{
			DialogManager.m_Singleton.setDialog("Book", m_contents);
			Time.timeScale = 0f;
		}

		if(m_interactable && Input.GetKeyDown(KeyCode.F))
		{
			DialogManager.m_Singleton.closeDialog();
			Time.timeScale = 1f;
		}
	}
}
