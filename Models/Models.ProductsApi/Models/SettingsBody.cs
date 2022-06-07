using System;
namespace Models.ProductsApi.Models
{
    public class SettingsBody
    {
        public SettingsBody()
        {
        }


        public SizesModel sizes { get; set; }

        public GendersModel genders { get; set; }

        public ColorsModel colors { get; set; }
    }
}
