using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathFade : MonoBehaviour
{
    public Image whiteScreen;

    // Start is called before the first frame update
    void Start()
    {
        whiteScreen.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    public void FadeIn()
    {
        whiteScreen.CrossFadeAlpha(1.0f, 3.0f, true);
    }

    public void FadeOut()
    {
        whiteScreen.CrossFadeAlpha(0.0f, 3.0f, true);
    }
}
