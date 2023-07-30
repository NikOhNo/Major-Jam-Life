using Assets.Scripts.Gameplay.Application.Question;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResponderDisplay : MonoBehaviour
{
    [SerializeField]
    Transform respondersParent;

    [SerializeField]
    GameObject responderPrefab;

    List<Responder> responders = new List<Responder>();

    public void CreateResponder(Question question, string response, int index)
    {
        Responder newResponder = Instantiate(responderPrefab, respondersParent).GetComponent<Responder>();

        // Set text for response
        newResponder.GetComponent<Responder>().SetText(response);

        // Add callback for button index to tell question which index was selected
        newResponder.GetComponent<Responder>().AddListener(TellQuestionIndexSelected(question, index));

        responders.Add(newResponder);
    }

    private static UnityAction TellQuestionIndexSelected(Question question, int index)
    {
        return () => question.SetSelectedResponse(index);
    }

    public void ClearAllResponders()
    {
        // Destroy all responder buttons
        foreach (Responder responder in responders)
        {
            Destroy(responder.gameObject);
        }

        responders.Clear();
    }

    public void SetActive(bool enabled)
    {
        gameObject.SetActive(enabled);
    }

}
