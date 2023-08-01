using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (img.fillAmount <= 0.4f)
        {
            img.color = new Color(0.7215686f, 0.0509804f, 0.282353f, 1);
        }
        else if (img.fillAmount <= 0.7f)
        {
            img.color = new Color(0.9490197f, 0.5921569f, 0.1411765f, 1);
        }
        else
        {
            img.color = new Color(0.3764706f, 0.7764707f, 0.5372549f, 1);
        }
    }
}
