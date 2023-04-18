using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    [SerializeField] private Text Message;
    // Start is called before the first frame update
    public IEnumerator ShowMessage(string text)
    {
        Message.text = text;
        yield return new WaitForSeconds(3f);
        Message.text = null;
    }
}
