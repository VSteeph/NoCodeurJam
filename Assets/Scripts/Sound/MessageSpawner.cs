using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject MessageBox;

    public void SpawnMessage()
    {
        FeedbackMessage FM = Instantiate(MessageBox, this.transform.position, Quaternion.identity, this.transform).GetComponent<FeedbackMessage>();
        FM.SetUp(CIvEnergyManager.cIvEnergyManager.GetLastMessage());
    }
}
