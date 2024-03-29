﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models.Attributes
{
    /// <summary>
    /// Provides an attribute that compares FirstName/LastName and Password fields.
    /// </summary>
    public class EditNamePasswordEqualAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ChangePasswordViewModel data = (ChangePasswordViewModel)value;

            if (data.FirstName == data.NewPassword)
            {
                ErrorMessage = "The FirstName and password cannot be the same.";
                return false;
            }

            if (data.LastName == data.NewPassword)
            {
                ErrorMessage = "The LastName and password cannot be the same.";
                return false;
            }
            return true;
        }
    }
}
