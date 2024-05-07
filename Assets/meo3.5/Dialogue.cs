using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public List<string> Dialog = new List<string>();
    public int Count = 0;

    void Start()
    {
        Text.text = Dialog[Count];
    }

    public void TryNext()
    {
        if(Count + 1 < Dialog.Count)
        {
            Count++;
            Text.text = Dialog[Count];
        }
    }

    public void TryPrev()
    {
        if (Count - 1 >= 0)
        {
            Count--;
            Text.text = Dialog[Count];
        }
    }
}
