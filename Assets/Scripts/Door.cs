using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    public GameObject m_closedDoor;
    public GameObject m_openedDoor;

    bool m_interactable = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControl>())
            m_interactable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControl>())
            m_interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_interactable)
        {
            m_closedDoor.SetActive(!m_closedDoor.activeSelf);
            m_openedDoor.SetActive(!m_openedDoor.activeSelf);
        }
    }
}
