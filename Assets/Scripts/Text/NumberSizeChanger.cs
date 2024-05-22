using System;
using System.Text;
using TMPro;
using UnityEngine;

public class NumberSizeChanger : MonoBehaviour
{
    private TextMeshProUGUI _textUI;
    [SerializeField] private float _symbolSize;
    [TextArea] [SerializeField] private string _originText;

    private void Start()
    {
        FormatText();
    }

    private void OnValidate()
    {
        if (_textUI == null)
            _textUI = GetComponent<TextMeshProUGUI>();
        _textUI.text = "";
        FormatText();
    }

    private void FormatText()
    {
        StringBuilder _result = new StringBuilder();
        bool isNumberSet = false;
        for (int i = 0; i < _originText.Length; i++)
        {
            if (isNumberSet && (!IsSizeableCharacter(_originText[i])&&!IsEnglishSymbol(_originText[i])))
            {
                isNumberSet = false;
                _result.Append($"</size>");
            }

            if (!isNumberSet && (IsSizeableCharacter(_originText[i]) || IsEnglishSymbol(_originText[i])))
            {
                isNumberSet = true;
                _result.Append($"<size={_symbolSize}>");
            }

            _result.Append(_originText[i]);
        }
        _textUI.text = _result.ToString();
    }

    private bool IsSizeableCharacter(char symbol) =>!char.IsLetter(symbol) && symbol != ' ' && symbol !='\"'&& symbol !='\''&& symbol !=':' && symbol != '\t' && symbol !='.' && symbol !=','&& symbol !='?'&& symbol !='-'&& symbol !='\n';
    private bool IsEnglishSymbol(char symbol) => (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z');
}
