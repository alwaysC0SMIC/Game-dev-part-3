using System.Drawing.Text;

namespace Game_dev_S2_project_1
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;
        public Level.Direction keyPress = Level.Direction.None;
        public const int NUMBER_OF_LEVELS = 10;

        // private GameEngine field
        //Initialises the GameEngine field in the Form’s constructor and set the 
        //number-of-levels parameter
        public Form1()
        {
            InitializeComponent();
            gameEngine = new GameEngine(NUMBER_OF_LEVELS);
            PickUpLabel.Text = gameEngine.nopickups;

            UpdateDisplay();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //This method assigns movement of the character to WASD as well as the arrow keys
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Up
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                keyPress = Level.Direction.Up;
                gameEngine.TriggerMovement(keyPress);

                //Part 2 Q3.1
                gameEngine.TriggerAttack(keyPress);
                hitPointsLabel.Text = gameEngine.heroStats;
                PickUpLabel.Text = gameEngine.nopickups;

                //This is debug code that was used inititally to determine damage but is currently used for status of exit
                DamageLabel.Text = gameEngine.heroDamage;


                UpdateDisplay();
            }
            //Left
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                keyPress = Level.Direction.Left;
                gameEngine.TriggerMovement(keyPress);

                gameEngine.TriggerAttack(keyPress);
                hitPointsLabel.Text = gameEngine.heroStats;
                PickUpLabel.Text = gameEngine.nopickups;

                //This is debug code that was used inititally to determine damage but is currently used for status of exit
                DamageLabel.Text = gameEngine.heroDamage;

                UpdateDisplay();
            }
            //Right
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                keyPress = Level.Direction.Right;
                gameEngine.TriggerMovement(keyPress);

                gameEngine.TriggerAttack(keyPress);
                hitPointsLabel.Text = gameEngine.heroStats;
                PickUpLabel.Text = gameEngine.nopickups;

                //This is debug code that was used inititally to determine damage but is currently used for status of exit
                DamageLabel.Text = gameEngine.heroDamage;


                UpdateDisplay();
            }
            //Down
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                keyPress = Level.Direction.Down;
                gameEngine.TriggerMovement(keyPress);

                gameEngine.TriggerAttack(keyPress);
                hitPointsLabel.Text = gameEngine.heroStats;
                PickUpLabel.Text = gameEngine.nopickups;

                //This is debug code that was used inititally to determine damage but is currently used for status of exit
                DamageLabel.Text = gameEngine.heroDamage;

                UpdateDisplay();
            }
        }

        // Assigns GameEngine field’s ToString result to your display label’s text property
        public void UpdateDisplay()
        {
            IbIDisplay.Text = gameEngine.ToString();
        }

        //The label
        private void IbIDisplay_Click(object sender, EventArgs e)
        {
        }


        private void Up_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Up;
            gameEngine.TriggerMovement(keyPress);

            gameEngine.TriggerAttack(keyPress);
            hitPointsLabel.Text = gameEngine.heroStats;

            UpdateDisplay();
        }

        private void Down_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Down;
            gameEngine.TriggerMovement(keyPress);

            gameEngine.TriggerAttack(keyPress);
            hitPointsLabel.Text = gameEngine.heroStats;

            UpdateDisplay();
        }

        private void Right_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Right;
            gameEngine.TriggerMovement(keyPress);

            gameEngine.TriggerAttack(keyPress);
            hitPointsLabel.Text = gameEngine.heroStats;

            UpdateDisplay();
        }

        private void Left_Click(object sender, EventArgs e)
        {

            keyPress = Level.Direction.Left;
            gameEngine.TriggerMovement(keyPress);

            gameEngine.TriggerAttack(keyPress);
            hitPointsLabel.Text = gameEngine.heroStats;


            UpdateDisplay();
        }

        private void DamageLabel_Click(object sender, EventArgs e)
        {

        }
    }
}//References:
//https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keypresseventargs.handled?view=windowsdesktop-7.0
