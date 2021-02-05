using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private int _gemCout = 0;

    public void Score()
    {
        _gemCout++;
        _score.text = _gemCout.ToString();
    }
}
