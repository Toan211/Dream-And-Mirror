using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InteractableObjects
{
    public class Door : InteractableObject
    {
        public GameObject m_closedDoor;
        public GameObject m_openedDoor;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(m_interactKey) && m_isInteractable)
            {
                m_closedDoor.SetActive(!m_closedDoor.activeSelf);
                m_openedDoor.SetActive(!m_openedDoor.activeSelf);
            }
        }
    }
}