#region

using UnityEngine;

#endregion

public class MenuNavigation : MonoBehaviour {
    private static ButtonSelect _selectedButton;
    private static Color _defaultColor = Color.black;
    private static Color _selectedColor = new Color32(16, 120, 9, 255);

    private void OnEnable() {
        if (_selectedButton != null) _selectedButton.ChangeTextColor(_defaultColor);
    }

    public static void ChangeSelection(ButtonSelect _button = null) {
        if (_selectedButton != null) _selectedButton.ChangeTextColor(_defaultColor);
        _selectedButton = _button;
        if (_selectedButton != null) _selectedButton.ChangeTextColor(_selectedColor);
    }
}