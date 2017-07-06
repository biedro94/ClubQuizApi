using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApi.Models
{
    public class Quiz
    {
        [Key]
        public int id { get; set; }
        public string imgUrl { get; set; }
        public string league { get; set; }
        public string goodAnswer { get; set; }

    }
}