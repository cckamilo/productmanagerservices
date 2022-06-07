using System;
using System.Collections.Generic;

namespace Models.ProductsApi.Models
{
    public class SettingsModel
    {
        public SettingsModel()
        {
        }

        public List<SizesModel> sizes { get; set; }

        public List<GendersModel> genders { get; set; }

        public List<ColorsModel> colors { get; set; }
    }
}
