using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackMessage : MonoBehaviour
{
    [SerializeField] private Text messageText;

    public void SetUp(string message)
    {
        messageText.text = message;
        Invoke("DestroyThis", 3);
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
