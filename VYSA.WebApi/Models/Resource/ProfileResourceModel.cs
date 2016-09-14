﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;

namespace VYSA.WebApi.Models.Resource
{
    public class ProfileResourceModel
    {
        public String UserName { get; set; }
        [Display(Name="Member Since")]
        public String UserCreatedDate { get; set; }
        public String Email { get; set; }
        public Boolean Approved { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public Boolean AnyPlayers { get; set; }
        public IEnumerable<Guardian> Guardians { get; set; }
        public Boolean AnyGuardians { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
        public Boolean AnyRegistrations { get; set; }
    }
}