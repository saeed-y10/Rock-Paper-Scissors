using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblPlayer1Score.Text = "0";
            lblPlayer2Score.Text = "0";

            RoundInfo.Player1Choice = enGameChoice.Rock;
            RoundInfo.Player2Choice = enGameChoice.Rock;
            RoundInfo.winner = enWinner.Draw;
        }

        struct stRoundInfo
        {
            public enGameChoice Player1Choice;
            public enGameChoice Player2Choice;
            public enWinner winner;
        }

        stRoundInfo RoundInfo;

        private enum enGameChoice
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        private enum enWinner
        {
            Player1,
            Player2,
            Draw
        }

        private enGameChoice GetRandomChoice()
        {
            Random rnd = new Random();

            return (enGameChoice)rnd.Next(1, 3);
        }

        private enWinner GetWinner(enGameChoice Player1Choice, enGameChoice Player2Choice)
        {
            if (Player1Choice == Player2Choice)
                return enWinner.Draw;

            else
            {
                switch (Player1Choice)
                {
                    case enGameChoice.Rock:
                        if (Player2Choice == enGameChoice.Paper)
                            return enWinner.Player2;
                        break;

                    case enGameChoice.Paper:
                        if (Player2Choice == enGameChoice.Scissors)
                            return enWinner.Player2;
                        break;

                    case enGameChoice.Scissors:
                        if (Player2Choice == enGameChoice.Rock)
                            return enWinner.Player2;
                        break;
                }

                return enWinner.Player1;
            }

        }

        private void UpdateChoiceImg(PictureBox pictureBox, enGameChoice Choice)
        {
            if (Choice == enGameChoice.Rock)
                pictureBox.Image = Properties.Resources.rock;

            else if (Choice == enGameChoice.Paper)
                pictureBox.Image = Properties.Resources.paper;

            else
                pictureBox.Image = Properties.Resources.scissors;
        }

        private void UpdatePlayersChoiceImg()
        {
            UpdateChoiceImg((PictureBox)pbPlayer1Choice, RoundInfo.Player1Choice);
            UpdateChoiceImg((PictureBox)pbPlayer2Choice, RoundInfo.Player2Choice);
        }

        private void UpdateRoundResult()
        {
            if (RoundInfo.winner == enWinner.Player1)
                pbRoundWinner.Image = Properties.Resources.Winner;

            else if (RoundInfo.winner == enWinner.Player2)
                pbRoundWinner.Image = Properties.Resources.Loser;

            else
                pbRoundWinner.Image = Properties.Resources.Draw;
        }

        private void UpdateScoreBoard()
        {
            if (RoundInfo.winner == enWinner.Player1)
                lblPlayer1Score.Text = (Convert.ToInt32(lblPlayer1Score.Text) + 1).ToString();

            else if (RoundInfo.winner == enWinner.Player2)
                lblPlayer2Score.Text = (Convert.ToInt32(lblPlayer2Score.Text) + 1).ToString();
        }

        private void ResetGame()
        {
            lblPlayer1Score.Text = "0";
            lblPlayer2Score.Text = "0";

            pbPlayer1Choice.Image = null;
            pbPlayer2Choice.Image = null; 
            pbRoundWinner.Image = null;
        }

        private void SetRoundInfo(enGameChoice Player1Chpice)
        {
            RoundInfo.Player1Choice = Player1Chpice;
            RoundInfo.Player2Choice = GetRandomChoice();
            RoundInfo.winner = GetWinner(RoundInfo.Player1Choice, RoundInfo.Player2Choice);

            UpdatePlayersChoiceImg();
            UpdateRoundResult();
            UpdateScoreBoard();
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            SetRoundInfo(enGameChoice.Rock);
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            SetRoundInfo(enGameChoice.Paper);
        }

        private void btnSicssors_Click(object sender, EventArgs e)
        {
            SetRoundInfo(enGameChoice.Scissors);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
