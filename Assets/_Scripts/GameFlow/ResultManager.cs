using System;
using _Scripts.Environment;
using TMPro;
using UnityEngine;

namespace _Scripts.GameFlow
{
    public class ResultManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resultTxt;
        [SerializeField] private TextMeshProUGUI resultTitle;
        [SerializeField] private GameObject resultUI;

        private static float? _previousGameResult;
    
        public enum Result
        {
            Lose,
            Win
        }
        private void OnEnable()
        {
            GameCompleteCollider.CompleteGame += OnResult;
        }
        private void OnDisable()
        {
            GameCompleteCollider.CompleteGame -= OnResult;
        }
    
        private void OnResult(Result result)
        {
            resultUI.SetActive(true);
            switch (result)
            {
                case Result.Win:
                    var time = (float)Math.Round(Time.time - GameStateManager.gameStartTime, 2);
                    resultTitle.SetText($"Вы выиграли за {time} с");
                
                    if (_previousGameResult == null)
                    {
                        _previousGameResult = time;
                        return;
                    }
                    resultTxt.SetText($"{_previousGameResult} с");
                    _previousGameResult = time;
                    break;
            
                case Result.Lose:
                    resultTitle.SetText("Вы проиграли");
                    break;
            }
        }
    }
}
