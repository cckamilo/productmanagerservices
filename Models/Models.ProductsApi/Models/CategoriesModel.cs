﻿using System;
using System.Collections.Generic;

namespace Models.ProductsApi.Models
{
    public class CategoriesModel
    {
        public CategoriesModel()
        {
            //this.subCategories = new List<SubCategoriesModel>();
        }
        public string id { get; set; }

        public string name { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime? modificationDate { get; set; }

        public bool active { get; set; }

        //public List<SubCategoriesModel> subCategories { get; set; }



    }
}
