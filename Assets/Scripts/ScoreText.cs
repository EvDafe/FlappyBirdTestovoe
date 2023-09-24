using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void SetText(int score)
    {
        _text.text = score.ToString();
    }
}
