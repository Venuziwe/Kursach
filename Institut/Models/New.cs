using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institut.Models
{
    public class New
    {
        //Айди новости
        public int NewId { get; set; }
        //Заголовок
        public string Head { get; set; }
        //Описание
        public string Description { get; set; }
        //Дата
        public DateTime Date { get; set; }
    }
}