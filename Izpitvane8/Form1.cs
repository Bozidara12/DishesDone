using Izpitvane8.Controller;
using Izpitvane8.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Izpitvane8
{
    public partial class Form1 : Form
    {
        DishesController dishController = new DishesController();
        DishTypeController dishTypeController = new DishTypeController();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Dishes dish)
        {
            txt1.BackColor = Color.White;
            txt1.Text = dish.Id.ToString();
            txt2.Text = dish.NameDish;
            txt3.Text = dish.Description;
            txt4.Text=dish.Price.ToString();    
            txt5.Text=dish.Weight.ToString();
            cmb1.Text=dish.DishTypeID.ToString();
        }
        private void ClearScreen()
        {
            txt1.BackColor = Color.White;
            txt1.Clear();
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            txt2.Clear();
            cmb1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<DishType> allDishType = dishTypeController.GetAllDishType();
            cmb1.DataSource = allDishType;
            cmb1.DisplayMember = "Type";
            cmb1.ValueMember = "Id";

            btn5_Click(sender, e);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            List<Dishes> allDishes = dishController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allDishes)
            {
                listBox1.Items.Add($"№{item.Id}.Име:{item.NameDish}.Описание:{item.Description}." +
                    $"Цена:{item.Price}лв..Грамаж:{item.Weight}г..Тип:{item.DishType.Type}");
            }
        }
        private void btnADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt3.Text) || txt3.Text == "")
            {
                MessageBox.Show("Въведи данни");

                txt3.Focus();
                return;
            }
            Dishes newDish = new Dishes();
            newDish.NameDish = txt2.Text;
            newDish.Description=txt3.Text;
            newDish.Price=int.Parse(txt4.Text);
            newDish.Weight=double.Parse(txt5.Text);
            newDish.DishTypeID = (int)cmb1.SelectedValue;

            dishController.Create(newDish);
            MessageBox.Show("Записът е успешно добавен");
            ClearScreen();
            btn5_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            if (string.IsNullOrEmpty(txt2.Text))
            {
                Dishes findedDishes = dishController.Get(findId);
                if (findedDishes == null)
                {
                    MessageBox.Show("Няма такъв запис в бд");
                    txt1.BackColor = Color.Red;
                    txt1.Focus();
                    return;
                }
                LoadRecord(findedDishes);
            }
            else
            {
                Dishes updatedDishes = new Dishes();
                updatedDishes.NameDish = txt2.Text;
                updatedDishes.Description =txt3.Text;
                updatedDishes.Price=int.Parse(txt4.Text);
                updatedDishes.Weight=double.Parse(txt5.Text);  
                updatedDishes.DishTypeID = (int)cmb1.SelectedValue;

                dishController.Update(findId, updatedDishes);
            }
            btn5_Click(sender, e);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Dishes findedDishes = dishController.Get(findId);
            if (findedDishes == null)
            {
                MessageBox.Show("Няма такъв запис в БД");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecord(findedDishes);

            DialogResult answer = MessageBox.Show("наистина ли искате да изтриете запис номер " +
                findId + "?", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                dishController.Delete(findId);
            }
            btn5_Click(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Dishes findedDishes = dishController.Get(findId);
            if (findedDishes == null)
            {
                MessageBox.Show("Няма такъв запис в БД");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecord(findedDishes);
        }

    }
    
    
}
