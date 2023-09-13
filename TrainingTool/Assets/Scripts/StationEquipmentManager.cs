using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationEquipmentManager : MonoBehaviour
{
    [SerializeField] private RawImage _buttonImage;
    private Button _button;
    private Sprite _icon;
    public Sprite Icon
    {
        set
        {
            _icon = value;
            _buttonImage.texture = _icon.texture;
        }
    }
    private void Start()
    {
        _button = GetComponent<Button>();
    }

}
