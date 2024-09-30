using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPainFlash : MonoBehaviour
{
    private Color _painColour;
    private SpriteRenderer _spr;
    private Shader _GUItxt;
    private Shader _default;
    private bool _flashing = false;
    public bool painTime;
    private void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
        _GUItxt = Shader.Find("GUI/Text Shader");
        _default = Shader.Find("Sprites/Default");
        _painColour = new Color(1f, 0.74117647058f, 0.54901960784f, 1f);
    }
    private void FixedUpdate()
    {
        if (!painTime)
            return;
        if (_flashing)
            return;
        _flashing = true;
        StartCoroutine(FlashPain());
    }

    private IEnumerator FlashPain()
    {
        _spr.material.shader = _GUItxt;
        _spr.color = _painColour;
        yield return new WaitForSeconds(0.05f);
        _spr.material.shader = _default;
        _spr.color = Color.white;
        _flashing = false;
        StopCoroutine(FlashPain());
    }
}
