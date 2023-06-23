using Microsoft.VisualBasic.Logging;
using Zadacha13_Animals.data.model;
using Zadacha13_Animals.logic;

namespace Zadacha13_Animals
{
    public partial class Form1 : Form
    {
        AnimalLogic animalsController = new AnimalLogic();
        BreedLogic breedController = new BreedLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = breedController.GetAllBreeds();
            comboBox1.DataSource = allBreeds;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            btnSelectAll_Click(sender, e);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Animal> allDogs = animalsController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allDogs)
            {
                listBox1.Items.Add($"{item.Id}. {item.AnimalName} - Age: {item.Age} Breed:{item.Breed.BreedName}");
            }
        }

        private void LoadRecord(Animal animal)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = animal.Id.ToString();
            textBox2.Text = animal.AnimalName;
            textBox3.Text = animal.Age.ToString();
            comboBox1.Text = animal.Breed.BreedName;
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                textBox2.Focus(); return;
            }
            Animal newAnimal = new Animal();
            newAnimal.Age = int.Parse(textBox3.Text);
            newAnimal.AnimalName = textBox2.Text;
            newAnimal.BreedId = (int)comboBox1.SelectedValue;
            animalsController.Create(newAnimal);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnSelectAll_Click(sender, e);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0; 
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            { 
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus(); return;
            }
            else 
            {
                findId = int.Parse(textBox1.Text);
            }
            Animal findedAnimal = animalsController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedAnimal);
        }
        private void btnUpd_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            { 
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus(); return;
            
            }
            else 
            {
                findId = int.Parse(textBox1.Text);
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Animal findedAnimal = animalsController.Get(findId);
                if (findedAnimal == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    textBox1.BackColor = Color.Red;
                    textBox1.Focus();
                    return;
                }
                LoadRecord(findedAnimal);
            }
            else 
            {
                Animal updatedAnimal = new Animal();
                updatedAnimal.AnimalName = textBox2.Text;
                updatedAnimal.Age = int.Parse(textBox3.Text);
                updatedAnimal.BreedId = (int)comboBox1.SelectedValue;
                animalsController.Update(findId, updatedAnimal);
            }
            btnSelectAll_Click(sender, e);
        }
    }
    
}