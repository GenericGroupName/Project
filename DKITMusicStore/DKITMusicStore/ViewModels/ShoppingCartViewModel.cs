using DKITMusicStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DKITMusicStore.ViewModels
{
    //[NotMapped]
    public class ShoppingCartViewModel
    {
        [Key]
        public int Id { get; set; }
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}