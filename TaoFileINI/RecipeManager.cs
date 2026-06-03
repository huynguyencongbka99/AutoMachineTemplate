using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoFileINI
{
    public static class RecipeManager
    {
        public static Recipe CurrentRecipe { get; private set; }

        public static void Load(string recipeName)
        {
            string path = $@"Recipe\{recipeName}.ini";

            CurrentRecipe = new Recipe
            {
                Name = recipeName
            };
        }
    }
}
