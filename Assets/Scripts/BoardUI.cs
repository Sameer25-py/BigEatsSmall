using System.Collections.Generic;
using System.Linq;
using BigEatsSmall.Core;
using TMPro;
using UnityEngine;

namespace BigEatsSmall
{
    public class BoardUI : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> gridBox;
        [SerializeField] private TMP_Text announcement;
        [SerializeField] private TMP_Text testNo;

        [SerializeField] private Color player1Color;
        [SerializeField] private Color player2Color;
        private Color _defaultColor = Color.black;
        [SerializeField] private Board ticTacToe;

        private void OnEnable()
        {
            gridBox = GetComponentsInChildren<TMP_Text>().ToList();
        }

        public void BoardCleanUp()
        {
            gridBox.ForEach(x =>
            {
                x.text = "0";
                x.color = Color.black;
            });

            announcement.enabled = false;
        }

        public void MarkBox(int value, int index)
        {
            gridBox[index].text = value.ToString();
        }

        public void ShowPlayerWin(int playerNumber, List<int> matchedIndices)
        {
            announcement.text = $"p{playerNumber} wins";
            announcement.enabled = true;
            var color = playerNumber == 1 ? player1Color : player2Color;
            for (var i = 0; i < 3; i++) gridBox[matchedIndices[i]].color = color;
        }

        public void ShowDrawAnnouncement()
        {
            announcement.text = "Match Draw";
            announcement.enabled = true;
        }

        public void UpdateTestNo(int testNumber)
        {
            testNo.text = $"Test#{testNumber}";
        }
    }
}