using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EventsWeb.Models
{
    [Display(Name = "Usuario")]
    public partial class User
    {
        public User()
        {
            Eventregister = new HashSet<Eventregister>();
            Eventschedule = new HashSet<Eventschedule>();
            Register = new HashSet<Register>();
            Session = new HashSet<Session>();
        }

        public int Iduser { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string Lastname { get; set; }

        [Display(Name = "Apellido Materno")]
        public string Surname { get; set; }

        [Display(Name = "Tipo de usuario")]
        public int Idusertype { get; set; }

        [Remote("doesUserNameExist", "User", HttpMethod = "POST", ErrorMessage = "Email already exists. Please enter a different email.")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Display(Name = "Tipo de usuario Paterno")]
        public virtual Usertype IdusertypeNavigation { get; set; }

        [Display(Name = "Informacion de usuario")]
        public virtual Userinfo Userinfo { get; set; }
        public virtual ICollection<Eventregister> Eventregister { get; set; }
        public virtual ICollection<Eventschedule> Eventschedule { get; set; }
        public virtual ICollection<Register> Register { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
