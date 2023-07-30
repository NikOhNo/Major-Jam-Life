using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Responder : MonoBehaviour
{
    [SerializeField]
    Transform respondersParent;

    [SerializeField]
    GameObject responderPrefab;

    public void CreateResponder()
    {
        Instantiate(responderPrefab, respondersParent);

        //responderPrefab.GetComponent<Button>().onClick.AddListener()
    }
}
