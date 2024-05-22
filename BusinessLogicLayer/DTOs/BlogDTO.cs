﻿using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entitys;
using DataLogicLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO_s
{
    public class BlogDTO
    {
        public BlogDTO() { }

        public BlogDTO(Blog blog)
        {
            id = blog.Id;
            Name = blog.Title;
            Description = blog.Text;
            CategoryName = blog.categorie.Title;
            Date = blog.Date;
            Username = blog.user.Username;
            ProfilePicture = blog.user.profile_picture;
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ProfilePicture { get; set; }
        public string Username { get; set; }
        public CategorieDTO categorie { get; set; }
        public UserDTO user { get; set; }

        public string Date {  get; set; }

    }
}
