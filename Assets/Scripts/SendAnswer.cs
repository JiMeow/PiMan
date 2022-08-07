using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendAnswer : MonoBehaviour
{
    public void send()
    {
        CheckAns.instance.Check(this.gameObject.GetComponent<Text>().text[0]);
    }
}
