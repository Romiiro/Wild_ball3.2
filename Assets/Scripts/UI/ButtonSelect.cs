#region

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

/// <summary>
/// ћетод мен€ющий цвет кнопки при выборе
/// </summary>
public class ButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private Text _text;
    private MenuNavigation _menuNavigation;

    public void OnPointerEnter(PointerEventData eventData) {
            MenuNavigation.ChangeSelection(this);
    }

    public void OnPointerExit(PointerEventData eventData) {
          MenuNavigation.ChangeSelection();
        
    }

    public void ChangeTextColor(Color color) {
        _text.color = color;
    }

    private void OnEnable() {
        _text = GetComponentInChildren<Text>();
    }

}