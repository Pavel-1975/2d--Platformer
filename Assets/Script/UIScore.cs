using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _player.ScoreChangedGem += WithdrawScore;
    }

    private void OnDisable()
    {
        _player.ScoreChangedGem -= WithdrawScore;
    }

    private void WithdrawScore(int _gemCout)
    {
        _score.text = _gemCout.ToString();
    }
}
