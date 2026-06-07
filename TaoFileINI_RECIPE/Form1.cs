using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaoFileINI_RECIPE
{
    public partial class Form1 : Form
    {
        private List<string> lstRecipe = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigManager.Load();

            LoadRecipeList();
            LoadRecipeList2();

            string lastRecipe = ConfigManager.System.LastRecipe;


            if (!string.IsNullOrWhiteSpace(
                ConfigManager.System.LastRecipe))
            {
                RecipeManager.Load(
                    ConfigManager.System.LastRecipe);

                LoadControl();

                listBoxRecipe.SelectedItem =
                    ConfigManager.System.LastRecipe;
            }
        }

        private void cbRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeManager.Load(cbRecipe.Text);
            LoadControl();

        }

        private void LoadRecipeList()
        {
            string recipeFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Recipe");

            if (!Directory.Exists(recipeFolder))
                Directory.CreateDirectory(recipeFolder);

            lstRecipe.Clear();

            foreach (string file in Directory.GetFiles(recipeFolder, "*.ini"))
            {
                lstRecipe.Add(Path.GetFileNameWithoutExtension(file));
            }

            lstRecipe.Sort();

            listBoxRecipe.DataSource = null;
            listBoxRecipe.DataSource = lstRecipe;
            
        }

        private void LoadRecipeList2()
        {
            List<string> lst = new List<string>();
            string recipeFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Recipe");

            if (!Directory.Exists(recipeFolder))
                Directory.CreateDirectory(recipeFolder);

            lst.Clear();

            foreach (string file in Directory.GetFiles(recipeFolder, "*.ini"))
            {
                lst.Add(Path.GetFileNameWithoutExtension(file));
            }


            cbRecipe.DataSource = lst;
        }

        private void LoadControl()
        {
            if (RecipeManager.CurrentRecipe == null)
                return;

            txtExposure.Text =
                RecipeManager.CurrentRecipe.Camera.Exposure.ToString();

            txtScore.Text =
                RecipeManager.CurrentRecipe.Vision.Score.ToString();

            lblModel.Text =
                RecipeManager.CurrentRecipe.Name;
        }


        private void btnSelectRecipe_Click(object sender, EventArgs e)
        {
            if (listBoxRecipe.SelectedItem == null)
                return;

            string recipeName =
                listBoxRecipe.SelectedItem.ToString();

            RecipeManager.Load(recipeName);

            ConfigManager.System.LastRecipe = recipeName;

            ConfigManager.Save();

            LoadControl();
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            string recipeName =
                txtRecipeName.Text.Trim();

            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Nhập tên Recipe");
                return;
            }

            RecipeManager.SaveAs(recipeName);

            LoadRecipeList();
            LoadRecipeList2();

            listBoxRecipe.SelectedItem = recipeName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RecipeManager.CurrentRecipe.Camera.Exposure = double.Parse(txtExposure.Text);

            RecipeManager.CurrentRecipe.Vision.Score =
                double.Parse(txtScore.Text);

            RecipeManager.Save();
        }
    }
}
