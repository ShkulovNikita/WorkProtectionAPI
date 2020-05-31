using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uirsWorkProtection
{
    public class UserInfo
    {
        public System.Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Profession { get; set; }

        public UserInfo() { }

        public UserInfo(Guid id, string surname, string name, string patronymic, string profession)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Profession = profession;
        }
    }
}