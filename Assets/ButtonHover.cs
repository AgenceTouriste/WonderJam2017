using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text myText;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.red;

    void Start()
    {
        myText = GetComponentInChildren<Text>();
        myText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.color = normalColor;
    }
}