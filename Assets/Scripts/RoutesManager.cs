using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DialogManament;

namespace RoutesManagement
{
    public class RoutesManager : MonoBehaviour
    {

        static public RoutesManager m_Singleton;

        [Header("Essential:")]
        public GameObject m_DecisionBox;
        public TextMeshProUGUI m_DecisionTitleText;
        public GameObject m_ListOfChoicedButtons;
        List<Button> m_Choices = new List<Button>();
        Decision m_Decisions;

        bool m_isConsidering = false;

        [Header("Start-up stuffs:")]
        public Dialogue m_fisrtTalk;
        public Decision m_firstDecision;

        private void Awake()
        {
            if (m_Singleton == null)
                m_Singleton = this;

            this.initialSetup();
        }

        private void Start()
        {
            DialogManager.m_Singleton.startDialogue(m_fisrtTalk);
            this.setDecision(m_firstDecision);
            m_isConsidering = true;
        }

        private void Update()
        {
            //Avoid overlaping with DialogBox.
            //This implementation leads to DialogManager has
            //higher priority than RoutesManager,
            //which is OK because we want to talk before making decision
            if(!DialogManager.m_Singleton.m_isDialoging)
            {
                if (m_isConsidering)
                {
                    this.startDeciding();
                }
            }
            
        }

        public void setConsiderationState(bool isConsidering)
        {
            m_isConsidering = isConsidering;
        }

        //Get buttons and temporarily disable them
        //Hide decision box
        void initialSetup()
        {
            //Get buttons
            for(int i=0; i<m_ListOfChoicedButtons.transform.childCount; i++)
            {
                Transform child = m_ListOfChoicedButtons.transform.GetChild(i);
                m_Choices.Add(child.gameObject.GetComponent<Button>());

                //Hide it 'cause we haven't needed it yet
                child.gameObject.SetActive(false);
            }

            //Hiding the box
            m_DecisionBox.SetActive(false);
        }

        //Prepare list of options, their contents and results
        public void setDecision(Decision decision)
        {
            m_Decisions = decision;

            m_DecisionTitleText.text = m_Decisions.m_title;
            for(int i=0; i<m_Decisions.m_options.Length; i++)
            {
                TextMeshProUGUI buttonText = m_Choices[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                buttonText.text = m_Decisions.m_options[i].m_content;

                //Clear previous stuffs
                m_Choices[i].onClick.RemoveAllListeners();
                //Set new stuffs
                m_Choices[i].onClick.AddListener(m_Decisions.m_options[i].m_resultTo.Invoke);

                m_Choices[i].gameObject.SetActive(true);
            }
        }

        public void startDeciding()
        {
            //Preventing player run around
            GameManager.m_Singleton.disableCharacterController();

            //setDecision(decision);

            m_DecisionBox.SetActive(true);
        }

        //Note: This function need to be added to [m_resultTo] of 
        //all existing Option variable
        public void closeDecisionBox()
        {
            m_isConsidering = false;

            m_DecisionBox.SetActive(false);

            for(int i=0; i<m_Choices.Count; i++)
            {
                m_Choices[i].gameObject.SetActive(false);
            }

            //You can run around after decision
            GameManager.m_Singleton.enableCharacterController();
        }
    }
}