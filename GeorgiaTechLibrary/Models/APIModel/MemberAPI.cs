﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgiaTechLibraryAPI.Models.APIModel
{
    public class MemberAPI
    {
        public long Ssn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PictureId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime CardExpirationDate { get; set; }
    }
}
