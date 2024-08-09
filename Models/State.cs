using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BankTransaction.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        public string StateName { get; set; }

        //public List<SelectListItem> StateList { get; set; }
    }
}
