﻿using Obligatorio1_DA1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_DA1.Domain
{
    public abstract class Item
    {

        private Category _category;

        public User User { get; set; }
        public string Notes { get; set; }


        public Category Category
        {
            get => _category;
            set
            {
                if (!this.User.Categories.Contains(value))
                    throw new InvalidItemCategoryException();
                this._category = value;
            }

        }
    }
}