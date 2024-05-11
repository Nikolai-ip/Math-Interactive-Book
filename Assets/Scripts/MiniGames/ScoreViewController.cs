using TMPro;
using UnityEngine;

namespace MiniGames
{
    public class ScoreViewController:MonoBehaviour
    {
        [SerializeField] private string _separatedStr;
        [SerializeField] TextMeshProUGUI _textUI;
        
        public void OnValueChanged(object val1, object val2)
        {
            _textUI.text = val1 + _separatedStr + val2;
        }
    }
}