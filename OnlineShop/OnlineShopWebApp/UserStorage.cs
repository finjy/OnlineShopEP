﻿using System;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class UserStorage : IUserStorage
    {
        private const string fileName = @"Data/Users.xml";
        private List<User> _users = new List<User>();

        public void Add(SignUp signup)
        {
            var xDoc = XDocument.Load(fileName);
            var root = xDoc.Element("users");
            Guid id = Guid.NewGuid();
            root.Add(new XElement("user",
                         new XAttribute("id", id),
                         new XElement("firstname", signup.FirstName),
                         new XElement("lastname", signup.LastName),
                         new XElement("role", "Customer"),
                         new XElement("phone", signup.Phone),
                         new XElement("email", signup.Email),
                         new XElement("password", signup.Password)));

            xDoc.Save(fileName);
        }

        public User TryGetById(Guid id)
        {
            var user = GetAll().FirstOrDefault(user => user.Id == id);
            return user;
        }

        public List<User> GetAll()
        {
            var xDoc = XDocument.Load(fileName);
            _users = xDoc.Element("users")
                               .Elements("user")
                               .Select(user => new User(
                                       Guid.Parse(user.Attribute("id").Value),
                                       user.Element("firstname").Value,
                                       user.Element("lastname").Value,
                                       user.Element("role").Value,
                                       user.Element("phone").Value,
                                       user.Element("email").Value,
                                       user.Element("password").Value)).ToList();
            return _users;
        }

        public bool Authorize(SignIn signin)
        {
            var matchUser = GetAll().FirstOrDefault(user => user.Email == signin.Email && user.Password == signin.Password);
            if(matchUser == null)
            {
                return false;
            }
            return true;
        }

        public void ChangePassword(ChangePassword data)
        {
            var xDoc = XDocument.Load(fileName);
            var editUser = xDoc.Element("users")
                               .Elements("user")
                               .FirstOrDefault(u => Guid.Parse(u.Attribute("id").Value) == data.Id);

            var password = editUser.Element("password");
            password.Value = data.Password;

            xDoc.Save(fileName);
        }

        public void Edit(User user)
        {
            var xDoc = XDocument.Load(fileName);
            var editUser = xDoc.Element("users")
                               .Elements("user")
                               .FirstOrDefault(u => Guid.Parse(u.Attribute("id").Value) == user.Id);

            var firstName = editUser.Element("firstname");
            firstName.Value = user.FirstName;
            
            var lastName = editUser.Element("lastname");
            lastName.Value = user.LastName;

            var phone = editUser.Element("phone");
            phone.Value = user.Phone;

            var email = editUser.Element("email");
            email.Value = user.Email;

            xDoc.Save(fileName);
        }

        public void Remove(Guid id)
        {
            var xDoc = XDocument.Load(fileName);
            var root = xDoc.Element("users");

            var user = root.Elements("user")
                              .FirstOrDefault(user => Guid.Parse(user.Attribute("id").Value) == id);

            user.Remove();
            xDoc.Save(fileName);
        }
    }
}
