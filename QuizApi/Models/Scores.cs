using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApi.Models
{
    public class Scores
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
    }
}