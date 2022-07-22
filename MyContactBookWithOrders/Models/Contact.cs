﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyContactBookWithOrders.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}